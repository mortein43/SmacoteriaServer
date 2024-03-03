using Microsoft.Win32;
using SmacoteriaBDFinal.Model.Models;
using SmacoteriaBDFinal.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SmacoteriaBDFinal.View;


public partial class AddToDB : Window
{
    private ViewModelAddToDB viewModel;
    private Point startPoint;

    public AddToDB()
    {
        this.InitializeComponent();
        this.DataContext = new ViewModelAddToDB();
        this.viewModel = new ViewModelAddToDB();
        this.IdTextBlock.Visibility = Visibility.Collapsed;
        this.IdInput.Visibility = Visibility.Collapsed;
        this.MessageTextBlockError.Visibility = Visibility.Collapsed;
        this.MessageTextBlockSuccess.Visibility = Visibility.Collapsed;
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "PNG files (*.png)|*.png";

        if (openFileDialog.ShowDialog() == true)
        {
            string fileName = openFileDialog.SafeFileName;
            string destinationPath = Path.Combine("Photos", fileName);
            File.Copy(openFileDialog.FileName, destinationPath, true);

            this.txtFilePath.Text = destinationPath;
        }
    }

    private void AddDishButton_Click(object sender, RoutedEventArgs e)
    {
        this.AllFieldsBlack();
        if (this.NameInput.Text.Length != 0 && this.DescriptionInput.Text.Length != 0 && this.PriceInput.Text.Length != 0 && this.CountInput.Text.Length != 0 && this.CountTypeComboBox.Text.Length != 0 && this.CategoryComboBox.Text.Length != 0)
        {
            this.viewModel.AddNewDish(this.NameInput.Text, this.DescriptionInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text, this.txtFilePath.Text);
            this.ChangedMessage(true);
        }
        else
        {
            this.CheckFieldOnLength(this.NameInput.Text, this.DescriptionInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text);
            this.ChangedMessage(false);
        }
    }

    private void UpdateDishButton_Click(object sender, RoutedEventArgs e)
    {
        this.AllFieldsBlack();
        if (this.NameInput.Text.Length != 0 && this.DescriptionInput.Text.Length != 0 && this.PriceInput.Text.Length != 0 && this.CountInput.Text.Length != 0 && this.CountTypeComboBox.Text.Length != 0 && this.CategoryComboBox.Text.Length != 0)
        {
            this.viewModel.UpdateDish(int.Parse(this.IdInput.Text), this.NameInput.Text, this.DescriptionInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text, this.txtFilePath.Text);
            this.ChangedMessage(true);
        }
        else
        {
            this.CheckFieldOnLength(this.NameInput.Text, this.DescriptionInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text);
            this.ChangedMessage(false);
        }
    }

    private void DeleteDishButton_Click(object sender, RoutedEventArgs e)
    {
        this.AllFieldsBlack();
        if (this.NameInput.Text.Length != 0)
        {
            this.viewModel.DeleteDish(this.NameInput.Text);
            this.ChangedMessage(true);
        }
        else
        {
            this.CheckFieldOnLengthForDelete(this.NameInput.Text);
            this.ChangedMessage(false);
        }
    }

    private void AddAdditionButton_Click(object sender, RoutedEventArgs e)
    {
        this.AllFieldsBlack();
        if (this.NameInput.Text.Length != 0 && this.PriceInput.Text.Length != 0 && this.CountInput.Text.Length != 0 && this.CountTypeComboBox.Text.Length != 0 && this.CategoryComboBox.Text.Length != 0)
        {
            this.viewModel.AddNewAddition(this.NameInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text, this.txtFilePath.Text);
            this.ChangedMessage(true);
        }
        else
        {
            this.CheckFieldOnLengthForAdditions(this.NameInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text);
            this.ChangedMessage(false);
        }
    }

    private void UpdateAdditionButton_Click(object sender, RoutedEventArgs e)
    {
        this.AllFieldsBlack();
        if (this.NameInput.Text.Length != 0 && this.PriceInput.Text.Length != 0 && this.CountInput.Text.Length != 0 && this.CountTypeComboBox.Text.Length != 0 && this.CategoryComboBox.Text.Length != 0)
        {
            this.viewModel.UpdateAddition(int.Parse(this.IdInput.Text), this.NameInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text, this.txtFilePath.Text);
            this.ChangedMessage(true);
        }
        else
        {
            this.CheckFieldOnLengthForAdditions(this.NameInput.Text, this.PriceInput.Text, this.CountInput.Text, this.CountTypeComboBox.Text, this.CategoryComboBox.Text);
            this.ChangedMessage(false);
        }
    }

    private void DeleteAdditionButton_Click(object sender, RoutedEventArgs e)
    {
        this.AllFieldsBlack();
        if (this.NameInput.Text.Length != 0)
        {
            this.viewModel.DeleteAddition(this.NameInput.Text);
            this.ChangedMessage(true);
        }
        else
        {
            this.CheckFieldOnLengthForAdditionsDelete(this.NameInput.Text);
            this.ChangedMessage(false);
        }
    }

    private void CountInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        foreach (char c in e.Text)
        {
            if (!char.IsDigit(c))
            {
                e.Handled = true;
                return;
            }
        }
    }

    private void PriceInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (!float.TryParse(((TextBox)sender).Text + e.Text, out float result))
        {
            e.Handled = true;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;

        if (button != null && button.DataContext != null)
        {
            var dataContext = button.DataContext;

            if (dataContext is Dish dish)
            {
                this.IdInput.Text = dish.Id.ToString();
                this.NameInput.Text = dish.Name;
                this.DescriptionInput.Text = dish.Description;
                this.PriceInput.Text = dish.Price.ToString();
                this.CountInput.Text = dish.Count.ToString();
                this.CountTypeComboBox.Text = dish.CountType.ToString();
                this.txtFilePath.Text = dish.Photo;
            }
            else if (dataContext is Addition addition)
            {
                this.IdInput.Text = addition.Id.ToString();
                this.NameInput.Text = addition.Name;
                this.PriceInput.Text = addition.Price.ToString();
                this.CountInput.Text = addition.Count.ToString();
                this.CountTypeComboBox.Text = addition.CountType.ToString();
                this.txtFilePath.Text = addition.Photo;
            }
        }
    }

    private void ShowAddDish_Click(object sender, RoutedEventArgs e)
    {
        this.AllInputsEmpty();
        this.AllFieldsBlack();

        if (this.FindName("AllItemsScrollViewer") is ScrollViewer scrollViewer)
        {
            scrollViewer.Visibility = Visibility.Collapsed;
        }

        if (this.FindName("EditStackPanel") is StackPanel editStackPanel)
        {
            editStackPanel.Visibility = Visibility.Visible;
            Grid.SetColumn(editStackPanel, 1);
            Grid.SetColumnSpan(editStackPanel, 2);
        }

        this.AllInputsVisible();

        this.AllButtonsCollapsed();
        this.SetButtonVisibility("AddDishButton", Visibility.Visible);
    }

    private void ShowUpdateDish_Click(object sender, RoutedEventArgs e)
    {
        if (this.FindName("AllItemsControl") is ItemsControl itemsControl)
        {
            itemsControl.ItemsSource = this.viewModel.AllDishes;
        }

        this.AllInputsEmpty();
        this.AllFieldsBlack();

        if (this.FindName("AllItemsScrollViewer") is ScrollViewer scrollViewer)
        {
            scrollViewer.Visibility = Visibility.Visible;
        }

        if (this.FindName("EditStackPanel") is StackPanel editStackPanel)
        {
            editStackPanel.Visibility = Visibility.Visible;
            Grid.SetColumn(editStackPanel, 2);
            Grid.SetColumnSpan(editStackPanel, 1);
        }

        this.AllInputsVisible();

        this.AllButtonsCollapsed();
        this.SetButtonVisibility("UpdateDishButton", Visibility.Visible);
    }

    private void ShowDeleteDish_Click(object sender, RoutedEventArgs e)
    {
        if (this.FindName("AllItemsControl") is ItemsControl itemsControl)
        {
            itemsControl.ItemsSource = this.viewModel.AllDishes;
        }

        this.AllInputsEmpty();
        this.AllFieldsBlack();

        if (this.FindName("AllItemsScrollViewer") is ScrollViewer scrollViewer)
        {
            scrollViewer.Visibility = Visibility.Visible;
        }

        if (this.FindName("EditStackPanel") is StackPanel editStackPanel)
        {
            editStackPanel.Visibility = Visibility.Visible;
            Grid.SetColumn(editStackPanel, 2);
            Grid.SetColumnSpan(editStackPanel, 1);
        }

        this.NameInput.Visibility = Visibility.Visible;
        this.AllInputsCollapsed();

        if (this.FindName("NameTextBlock") is TextBlock textBlock)
        {
            textBlock.Visibility = Visibility.Visible;
        }

        this.AllButtonsCollapsed();
        this.SetButtonVisibility("DeleteDishButton", Visibility.Visible);
    }

    private void ShowAddAddition_Click(object sender, RoutedEventArgs e)
    {
        this.AllInputsEmpty();
        this.AllFieldsBlack();

        if (this.FindName("AllItemsScrollViewer") is ScrollViewer scrollViewer)
        {
            scrollViewer.Visibility = Visibility.Collapsed;
        }

        if (this.FindName("EditStackPanel") is StackPanel editStackPanel)
        {
            editStackPanel.Visibility = Visibility.Visible;
            Grid.SetColumn(editStackPanel, 1);
            Grid.SetColumnSpan(editStackPanel, 2);
        }

        this.AllInputsVisible();
        this.DescriptionTextBlock.Visibility = Visibility.Collapsed;
        this.DescriptionInput.Visibility = Visibility.Collapsed;

        this.AllButtonsCollapsed();
        this.SetButtonVisibility("AddAdditionButton", Visibility.Visible);
    }

    private void ShowUpdateAddition_Click(object sender, RoutedEventArgs e)
    {
        if (this.FindName("AllItemsControl") is ItemsControl itemsControl)
        {
            itemsControl.ItemsSource = this.viewModel.AllAdditions;
        }

        this.AllInputsEmpty();
        this.AllFieldsBlack();

        if (this.FindName("AllItemsScrollViewer") is ScrollViewer scrollViewer)
        {
            scrollViewer.Visibility = Visibility.Visible;
        }

        if (this.FindName("EditStackPanel") is StackPanel editStackPanel)
        {
            editStackPanel.Visibility = Visibility.Visible;
            Grid.SetColumn(editStackPanel, 2);
            Grid.SetColumnSpan(editStackPanel, 1);
        }

        this.AllInputsVisible();
        this.DescriptionTextBlock.Visibility = Visibility.Collapsed;
        this.DescriptionInput.Visibility = Visibility.Collapsed;

        this.AllButtonsCollapsed();
        this.SetButtonVisibility("UpdateAdditionButton", Visibility.Visible);
    }

    private void ShowDeleteAddition_Click(object sender, RoutedEventArgs e)
    {
        if (this.FindName("AllItemsControl") is ItemsControl itemsControl)
        {
            itemsControl.ItemsSource = this.viewModel.AllAdditions;
        }

        this.AllInputsEmpty();
        this.AllFieldsBlack();

        if (this.FindName("AllItemsScrollViewer") is ScrollViewer scrollViewer)
        {
            scrollViewer.Visibility = Visibility.Visible;
        }

        if (this.FindName("EditStackPanel") is StackPanel editStackPanel)
        {
            editStackPanel.Visibility = Visibility.Visible;
            Grid.SetColumn(editStackPanel, 2);
            Grid.SetColumnSpan(editStackPanel, 1);
        }

        this.NameInput.Visibility = Visibility.Visible;
        this.AllInputsCollapsed();

        if (this.FindName("NameTextBlock") is TextBlock textBlock)
        {
            textBlock.Visibility = Visibility.Visible;
        }

        this.AllButtonsCollapsed();
        this.SetButtonVisibility("DeleteAdditionButton", Visibility.Visible);
    }

    private void SetButtonVisibility(string buttonName, Visibility visibility)
    {
        if (this.FindName(buttonName) is Button button)
        {
            button.Visibility = visibility;
        }
    }

    private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            this.startPoint = e.GetPosition(null);
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
            Vector diff = this.startPoint - mousePos;

            if (Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + diff.Y);
            }

            this.startPoint = mousePos;
        }
    }

    private void AllFieldsBlack()
    {
        this.NameTextBlock.Foreground = Brushes.Black;
        this.DescriptionTextBlock.Foreground = Brushes.Black;
        this.PriceTextBlock.Foreground = Brushes.Black;
        this.CountTextBlock.Foreground = Brushes.Black;
        this.CountTypeTextBlock.Foreground = Brushes.Black;
        this.CategoryTextBlock.Foreground = Brushes.Black;
    }

    private void CheckFieldOnLength(string nameInput, string descriptionInput, string priceInput, string countInput, string countTypeComboBox, string categoryComboBox)
    {
        if (nameInput.Length == 0) this.NameTextBlock.Foreground = Brushes.Red;
        else if (descriptionInput.Length == 0) this.DescriptionTextBlock.Foreground = Brushes.Red;
        else if (priceInput.Length == 0) this.PriceTextBlock.Foreground = Brushes.Red;
        else if (countInput.Length == 0) this.CountTextBlock.Foreground = Brushes.Red;
        else if (countTypeComboBox.Length == 0) this.CountTypeTextBlock.Foreground = Brushes.Red;
        else if (categoryComboBox.Length == 0) this.CategoryTextBlock.Foreground = Brushes.Red;
    }

    private void CheckFieldOnLengthForDelete(string name)
    {
        if (name.Length == 0) this.NameTextBlock.Foreground = Brushes.Red;
    }

    private void CheckFieldOnLengthForAdditions(string nameInput, string priceInput, string countInput, string countTypeComboBox, string categoryComboBox)
    {
        if (nameInput.Length == 0) this.NameTextBlock.Foreground = Brushes.Red;
        else if (priceInput.Length == 0) this.PriceTextBlock.Foreground = Brushes.Red;
        else if (countInput.Length == 0) this.CountTextBlock.Foreground = Brushes.Red;
        else if (countTypeComboBox.Length == 0) this.CountTypeTextBlock.Foreground = Brushes.Red;
        else if (categoryComboBox.Length == 0) this.CategoryTextBlock.Foreground = Brushes.Red;
    }

    private void CheckFieldOnLengthForAdditionsDelete(string name)
    {
        if (name.Length == 0) this.NameTextBlock.Foreground = Brushes.Red;
    }

    private void ChangedMessage(bool v)
    {
        if (v)
        {
            this.MessageTextBlockError.Visibility = Visibility.Collapsed;
            this.MessageTextBlockSuccess.Visibility = Visibility.Visible;
        }
        else
        {
            this.MessageTextBlockSuccess.Visibility = Visibility.Collapsed;
            this.MessageTextBlockError.Visibility = Visibility.Visible;
        }
    }

    private void AllInputsEmpty()
    {
        this.MessageTextBlockError.Visibility = Visibility.Collapsed;
        this.MessageTextBlockSuccess.Visibility = Visibility.Collapsed;
        this.IdInput.Text = string.Empty;
        this.NameInput.Text = string.Empty;
        this.DescriptionInput.Text = string.Empty;
        this.PriceInput.Text = string.Empty;
        this.CategoryComboBox.Text = string.Empty;
        this.txtFilePath.Text = string.Empty;
        this.CountInput.Text = string.Empty;
        this.CountTypeComboBox.Text = string.Empty;
    }

    private void AllInputsVisible()
    {
        this.NameInput.Visibility = Visibility.Visible;
        this.DescriptionTextBlock.Visibility = Visibility.Visible;
        this.DescriptionInput.Visibility = Visibility.Visible;
        this.CountStackPanel.Visibility = Visibility.Visible;
        this.PriceTextBlock.Visibility = Visibility.Visible;
        this.PriceInput.Visibility = Visibility.Visible;
        this.CategoryTextBlock.Visibility = Visibility.Visible;
        this.CategoryComboBox.Visibility = Visibility.Visible;
        this.TxtFilePathTextBlock.Visibility = Visibility.Visible;
        this.txtFilePath.Visibility = Visibility.Visible;
        this.txtFilePathButton.Visibility = Visibility.Visible;
    }

    private void AllInputsCollapsed()
    {
        this.DescriptionTextBlock.Visibility = Visibility.Collapsed;
        this.DescriptionInput.Visibility = Visibility.Collapsed;
        this.CountStackPanel.Visibility = Visibility.Collapsed;
        this.PriceTextBlock.Visibility = Visibility.Collapsed;
        this.PriceInput.Visibility = Visibility.Collapsed;
        this.CategoryTextBlock.Visibility = Visibility.Collapsed;
        this.CategoryComboBox.Visibility = Visibility.Collapsed;
        this.TxtFilePathTextBlock.Visibility = Visibility.Collapsed;
        this.txtFilePath.Visibility = Visibility.Collapsed;
        this.txtFilePathButton.Visibility = Visibility.Collapsed;
    }

    private void AllButtonsCollapsed()
    {
        this.SetButtonVisibility("DeleteDishButton", Visibility.Collapsed);
        this.SetButtonVisibility("AddDishButton", Visibility.Collapsed);
        this.SetButtonVisibility("UpdateDishButton", Visibility.Collapsed);
        this.SetButtonVisibility("DeleteAdditionButton", Visibility.Collapsed);
        this.SetButtonVisibility("AddAdditionButton", Visibility.Collapsed);
        this.SetButtonVisibility("UpdateAdditionButton", Visibility.Collapsed);
    }
}
