using GalaSoft.MvvmLight.Command;
using SmacoteriaBDFinal.Controls;
using SmacoteriaBDFinal.Model.Models;
using SmacoteriaBDFinal.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace SmacoteriaBDFinal.ViewModel;

public class ViewModelMainWindow : INotifyPropertyChanged
{
    public ObservableCollection<Order> _orderForAcceptance = new ObservableCollection<Order>();
    public ObservableCollection<Order> _ordersAccepted = new ObservableCollection<Order>();
    public TCPControl tcpServer;

    public ViewModelMainWindow()
    {
        this.tcpServer = new TCPControl(this);
        this.AddToDb = new RelayCommand(this.ExecuteAddToDb, this.CanExecuteAddToDb);
    }

    private bool CanExecuteAddToDb()
    {
        return true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Initialize()
    {

    }

    public void ExecuteAcceptOrder(Order order)
    {
        order.Status = Order.Statuses.Прийняте;
        this._orderForAcceptance.Remove(order);
        this._ordersAccepted.Add(order);
    }

    public void ExecutePrintCheck(Order order)
    {
        FileControl.PrintCheck(order);
        this._ordersAccepted.Remove(order);
    }

    public ObservableCollection<Order> OrderForAcceptance
    {
        get
        {
            return this._orderForAcceptance;
        }

        set
        {
            this._orderForAcceptance = value;
            this.OnPropertyChanged(nameof(this.OrderForAcceptance));
        }
    }

    public ObservableCollection<Order> OrdersAccepted
    {
        get
        {
            return this._ordersAccepted;
        }

        set
        {
            this._ordersAccepted = value;
            this.OnPropertyChanged(nameof(this.OrdersAccepted));
        }
    }

    public ICommand AddToDb { get; set; }

    private void ExecuteAddToDb()
    {
        AddToDB addToDBWindow = new AddToDB();
        addToDBWindow.ShowDialog();
    }
}
