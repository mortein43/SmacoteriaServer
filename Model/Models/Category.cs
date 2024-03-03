namespace SmacoteriaBDFinal.Model.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    
    public List<Dish> Dishes { get; set; } = new();

    
    public List<Addition>? Additions { get; set; } = new();
}
