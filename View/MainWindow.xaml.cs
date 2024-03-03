using SmacoteriaBDFinal.Model.Models;
using SmacoteriaBDFinal.ViewModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmacoteriaBDFinal;


public partial class MainWindow : Window
{
    private Point startPoint;
    private Point startPointV;

    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void AcceptOrderButton_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;

        if (button != null && button.DataContext != null)
        {
            var dataContext = button.DataContext;

            if (dataContext != null && this.DataContext is ViewModelMainWindow viewModel)
            {
                Order order = (Order)dataContext;
                viewModel.ExecuteAcceptOrder(order);
            }
        }
    }

    private void PrintCheckButton_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;

        if (button != null && button.DataContext != null)
        {
            var dataContext = button.DataContext;

            if (dataContext != null && DataContext is ViewModelMainWindow viewModel)
            {
                Order order = (Order)dataContext;
                viewModel.ExecutePrintCheck(order);
            }
        }
    }

    private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.startPoint = e.GetPosition(null);
            this.startPointV = e.GetPosition(null);
        }
    }

    private void ScrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        ScrollViewer scrollViewer = sender as ScrollViewer;
        if (scrollViewer != null && e.LeftButton == MouseButtonState.Pressed)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = this.startPoint - mousePos;

            if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + diff.X);
            }

            this.startPoint = mousePos;
        }
    }

    private void ScrollViewerVertical_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        ScrollViewer scrollViewer = sender as ScrollViewer;
        if (scrollViewer != null && e.LeftButton == MouseButtonState.Pressed)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = this.startPointV - mousePos;

            if (Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + diff.Y);
            }

            this.startPointV = mousePos;
        }
    }
}