namespace SmacoteriaBDFinal.Controls;
using SmacoteriaBDFinal.Model.Models;
using System.Diagnostics;
using System.IO;

public class FileControl
{
    public static void PrintCheck(Order order)
    {
        string filePath = "check.txt";
        string content = new string('=', 26) + " СМАКОТЕРІЯ " + new string('=', 26) + "\n\n\n";

        int maxDishNameLength = order.Dishes.Max(d => d.Dish.Name.Length);

        foreach (DishInOrder dishInOrder in order.Dishes)
        {
            content += $"\n{dishInOrder.Dish.Name,-60}{dishInOrder.Dish.Price} грн\n";

            foreach (Addition addition in dishInOrder.Additions)
            {
                content += $"{addition.Name.PadLeft(addition.Name.Length + 7),-60}{addition.Price} грн\n";
            }
        }

        content += $"\n\n{"Загальна вартість:",-60}{order.TotalCost} грн\n";
        content += $"\nСпосіб оплати: {order.PaymentMethod}\n";
        content += $"Номер столика: {order.TableNumber}\n";
        content += $"Коментар: {order.Notice}\n\n";

        File.WriteAllText(filePath, content);
        Process.Start("notepad.exe", filePath);
    }
}
