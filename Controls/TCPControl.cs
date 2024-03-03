using Newtonsoft.Json;
using SmacoteriaBDFinal.Model.Models;
using SmacoteriaBDFinal.ViewModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace SmacoteriaBDFinal.Controls;

public class TCPControl
{
    private static int Port = 2000;
    private static readonly List<TcpClient> OnlineClients = new List<TcpClient>();
    ViewModelMainWindow viewModelMainWindow;

    public TCPControl(ViewModelMainWindow viewModelMainWindow)
    {
        this.viewModelMainWindow = viewModelMainWindow;
        TcpListener tcpListener = new TcpListener(Port);
        Thread _thread = new Thread(new ParameterizedThreadStart(NewServer));
        _thread.Start(new Tuple<TcpListener, ViewModelMainWindow>(tcpListener, viewModelMainWindow));
    }

    public static void NewServer(object obj)
    {
        var parameters = (Tuple<TcpListener, ViewModelMainWindow>)obj;
        TcpListener server = parameters.Item1;
        ViewModelMainWindow viewModelMainWindow = parameters.Item2;
        server.Start();
        while (true)
        {
            TcpClient tcpClient = server.AcceptTcpClientAsync().Result;
            OnlineClients.Add(tcpClient);
            Thread _thread = new Thread(new ParameterizedThreadStart(NewClient));
            _thread.Start(new Tuple<TcpClient, ViewModelMainWindow>(tcpClient, viewModelMainWindow));
        }
    }

    public static async void NewClient(object obj)
    {
        var parameters = (Tuple<TcpClient, ViewModelMainWindow>)obj;
        TcpClient tcpClient = parameters.Item1;
        ViewModelMainWindow viewModelMainWindow = parameters.Item2;
        SendListsToClient(tcpClient, OnlineClients.Count);
        while (obj != null)
        {
            byte[] bytesBuffer = new byte[4];
            int i;
            try
            {
                for (int j = OnlineClients.Count - 1; j >= 0; j--)
                {
                    if (SocketConnected(OnlineClients[j].Client) == false)
                    {
                        OnlineClients.RemoveAt(j);
                    }
                }

                while ((i = tcpClient.GetStream().Read(bytesBuffer, 0, bytesBuffer.Length)) != 0)
                {
                    try
                    {
                        Order receivedOrder = ReceiveOrderFromStream(tcpClient, bytesBuffer);
                        Application.Current.Dispatcher.Invoke(() =>
                            {
                                viewModelMainWindow._orderForAcceptance.Add(receivedOrder);
                            });
                        bytesBuffer = new byte[4];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        break;
                    }
                    finally
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public static string GetLocalIPAddress()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new Exception("an error occured");
    }

    public static bool SocketConnected(Socket s)
    {
        bool canRead = s.Poll(1000, SelectMode.SelectRead);
        bool dataAvailable = (s.Available == 0);
        if (canRead & dataAvailable)
        {
            return false;
        }

        return true;
    }

    public static string GetIpAddress(TcpClient tcpClient)
    {
        return ((IPEndPoint)tcpClient.Client.LocalEndPoint).Address.ToString();
    }

    public static void SendListsToClient(TcpClient tcpClient, int tableNumber)
    {
        List<Dish> dishes = DataControl.GetDishes();
        List<Addition> additions = DataControl.GetAdditions();
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            byte[] tableNumberBytes = BitConverter.GetBytes(tableNumber);
            tcpClient.GetStream().Write(tableNumberBytes, 0, tableNumberBytes.Length);

            string dishesJson = JsonConvert.SerializeObject(dishes, settings);
            string additionsJson = JsonConvert.SerializeObject(additions, settings);

            byte[] dishesBytes = Encoding.UTF8.GetBytes(dishesJson);
            byte[] additionsBytes = Encoding.UTF8.GetBytes(additionsJson);

            byte[] sizeBytes = BitConverter.GetBytes(dishesBytes.Length);
            tcpClient.GetStream().Write(sizeBytes, 0, sizeBytes.Length);
            tcpClient.GetStream().Write(dishesBytes, 0, dishesBytes.Length);

            sizeBytes = BitConverter.GetBytes(additionsBytes.Length);
            tcpClient.GetStream().Write(sizeBytes, 0, sizeBytes.Length);
            tcpClient.GetStream().Write(additionsBytes, 0, additionsBytes.Length);

            Console.WriteLine("Lists sent to client.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending lists to client: {ex.Message}");
        }
    }

    static Order ReceiveOrderFromStream(TcpClient tcpClient, byte[] bytesBuffer)
    {
        int dataSize = BitConverter.ToInt32(bytesBuffer, 0);

        byte[] dishBytes = new byte[dataSize];
        tcpClient.GetStream().Read(dishBytes, 0, dishBytes.Length);
        string orderJson = Encoding.UTF8.GetString(dishBytes);

        return JsonConvert.DeserializeObject<Order>(orderJson);
    }

    public static void AddDish(Dish newDish, string? photo)
    {
        foreach (var tcpClient in OnlineClients)
        {
            SendDataOverTcp(tcpClient, 0, 0, newDish, photo);
        }
    }

    public static void UpdateDish(Dish newDish, string? photo)
    {
        foreach (var tcpClient in OnlineClients)
        {
            SendDataOverTcp(tcpClient, 0, 1, newDish, photo);
        }
    }

    public static void DeleteDish(Dish dish)
    {
        foreach (var tcpClient in OnlineClients)
        {
            SendDataOverTcp(tcpClient, 0, 2, dish);
        }
    }

    public static void AddAddition(Addition newAddition, string? photo)
    {
        foreach (var tcpClient in OnlineClients)
        {
            SendDataOverTcp(tcpClient, 1, 0, newAddition, photo);
        }
    }

    public static void UpdateAddition(Addition newAddition, string? photo)
    {
        foreach (var tcpClient in OnlineClients)
        {
            SendDataOverTcp(tcpClient, 1, 1, newAddition, photo);
        }
    }

    public static void DeleteAddition(Addition addition)
    {
        foreach (var tcpClient in OnlineClients)
        {
            SendDataOverTcp(tcpClient, 1, 2, addition);
        }
    }

    public static void SendDataOverTcp(TcpClient tcpClient, int typeobj, int typeoperation, object data, string? photo = null)
    {
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            byte[] typeobjBytes = BitConverter.GetBytes(typeobj);
            byte[] typeoperationBytes = BitConverter.GetBytes(typeoperation);

            tcpClient.GetStream().Write(typeobjBytes, 0, typeobjBytes.Length);
            tcpClient.GetStream().Write(typeoperationBytes, 0, typeoperationBytes.Length);

            string jsonData = JsonConvert.SerializeObject(data, settings);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonData);

            byte[] sizeBytes = BitConverter.GetBytes(jsonBytes.Length);
            tcpClient.GetStream().Write(sizeBytes, 0, sizeBytes.Length);
            tcpClient.GetStream().Write(jsonBytes, 0, jsonBytes.Length);

            if (photo != null)
            {
                byte[] imageBytes = File.ReadAllBytes(photo);
                sizeBytes = BitConverter.GetBytes(imageBytes.Length);
                tcpClient.GetStream().Write(sizeBytes, 0, sizeBytes.Length);
                tcpClient.GetStream().Write(imageBytes, 0, imageBytes.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending data over TCP: {ex.Message}");
        }
    }
}