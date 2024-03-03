namespace SmacoteriaBDFinal.ViewModel;

using SmacoteriaBDFinal.Controls;
using SmacoteriaBDFinal.Model.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

public class ViewModelAddToDB : INotifyPropertyChanged
{
    private ObservableCollection<Dish>? _allDishes = new();
    private ObservableCollection<Addition>? _alladditions = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ObservableCollection<Dish> AllDishes
    {
        get
        {
            return this._allDishes;
        }

        set
        {
            this._allDishes = value;
            this.OnPropertyChanged(nameof(this.AllDishes));
        }
    }

    public ObservableCollection<Addition> AllAdditions
    {
        get
        {
            return this._alladditions;
        }

        set
        {
            this._alladditions = value;
            this.OnPropertyChanged(nameof(this.AllAdditions));
        }
    }

    public ViewModelAddToDB()
    {
        this._allDishes = new ObservableCollection<Dish>(DataControl.unitOfWork.DishRepository.GetAll());
        this._alladditions = new ObservableCollection<Addition>(DataControl.unitOfWork.AdditionRepository.GetAll());
    }

    public void AddNewDish(string name, string description, string price, string count, string countTypeName, string categoryname, string? photo)
    {
        Dish.CountTypes countType = EnumControl.GetEnumValueByName<Dish.CountTypes>(countTypeName);
        var category = DataControl.unitOfWork.CategoryRepository.GetAll().FirstOrDefault(c => c.Name == categoryname);
        string newPhotoPath = null;
        string fileName = Path.GetFileName(photo);
        if (fileName.Length != 0)
        {
            switch (categoryname)
            {
                case "Круасани сендвічі":
                    newPhotoPath = Path.Combine("/", "Photos", "CroissantSandwiches", fileName).Replace('\\', '/');
                    break;
                case "Солодкі круасани":
                    newPhotoPath = Path.Combine("/", "Photos", "SweetCroissant", fileName).Replace('\\', '/');
                    break;
                case "Напої":
                    newPhotoPath = Path.Combine("/", "Photos", "Drinks", fileName).Replace('\\', '/');
                    break;
                default:
                    break;
            }
        }

        Dish newDish = new Dish { Name = name, Description = description, Price = float.Parse(price), Count = int.Parse(count), CountType = countType, CategoryId = category.Id, Photo = newPhotoPath };
        DataControl.unitOfWork.DishRepository.Insert(newDish);
        DataControl.unitOfWork.Save();
        TCPControl.AddDish(newDish, photo);
        this.AllDishes.Add(newDish);
    }

    public void UpdateDish(int id, string name, string description, string price, string count, string countTypeName, string categoryname, string? photo)
    {
        Dish newDish = DataControl.unitOfWork.DishRepository.GetAll().FirstOrDefault(d => d.Id == id);
        if (newDish != null)
        {
            Dish.CountTypes countType = EnumControl.GetEnumValueByName<Dish.CountTypes>(countTypeName);
            var category = DataControl.unitOfWork.CategoryRepository.GetAll().FirstOrDefault(c => c.Name == categoryname);
            newDish.Name = name;
            newDish.Description = description;
            newDish.Price = float.Parse(price);
            newDish.Count = int.Parse(count);
            newDish.CountType = countType;
            newDish.CategoryId = category.Id;

            var dish = this.AllDishes.FirstOrDefault(d => d.Id == id);
            dish = newDish;
            string newPhotoPath = null;
            string fileName = Path.GetFileName(photo);
            if (fileName.Length != 0)
            {
                switch (categoryname)
                {
                    case "Круасани сендвічі":
                        newPhotoPath = Path.Combine("/", "Photos", "CroissantSandwiches", fileName).Replace('\\', '/');
                        break;
                    case "Солодкі круасани":
                        newPhotoPath = Path.Combine("/", "Photos", "SweetCroissant", fileName).Replace('\\', '/');
                        break;
                    case "Напої":
                        newPhotoPath = Path.Combine("/", "Photos", "Drinks", fileName).Replace('\\', '/');
                        break;
                    default:
                        break;
                }
            }

            if (Path.GetFileName(newDish.Photo) != Path.GetFileName(newPhotoPath) && newPhotoPath != null)
            {
                newDish.Photo = newPhotoPath;
                dish.Photo = newPhotoPath;
            }
            else
            {
                photo = null;
            }

            DataControl.unitOfWork.DishRepository.Update(newDish);
            DataControl.unitOfWork.Save();
            TCPControl.UpdateDish(newDish, photo);
        }
        else
            MessageBox.Show("Страви з таким ім'ям не знайдено!");

    }

    public void DeleteDish(string name)
    {
        Dish dish = DataControl.unitOfWork.DishRepository.GetAll().FirstOrDefault(d => d.Name == name);

        if (dish != null)
        {
            DataControl.unitOfWork.DishRepository.Delete(dish);
            DataControl.unitOfWork.Save();
            TCPControl.DeleteDish(dish);
            this.AllDishes.Remove(dish);
        }
        else
        {
            MessageBox.Show("Страви з таким ім'ям не знайдено!");
        }
    }

    public void AddNewAddition(string name, string price, string count, string countTypeName, string categoryname, string? photo)
    {
        Addition.CountTypes countType = EnumControl.GetEnumValueByName<Addition.CountTypes>(countTypeName);
        var category = DataControl.unitOfWork.CategoryRepository.GetAll().FirstOrDefault(c => c.Name == categoryname);
        string newPhotoPath = null;
        string fileName = Path.GetFileName(photo);
        if (fileName.Length != 0)
            newPhotoPath = Path.Combine("/", "Photos", "Additions", fileName).Replace('\\', '/');

        Addition newAddition = new Addition { Name = name, Price = float.Parse(price), Count = int.Parse(count), CountType = countType, CategoryId = category.Id, Photo = newPhotoPath };
        DataControl.unitOfWork.AdditionRepository.Insert(newAddition);
        DataControl.unitOfWork.Save();
        TCPControl.AddAddition(newAddition, photo);
        this.AllAdditions.Add(newAddition);
    }

    public void UpdateAddition(int id, string name, string price, string count, string countTypeName, string categoryname, string? photo)
    {
        Addition newAddition = DataControl.unitOfWork.AdditionRepository.GetAll().FirstOrDefault(a => a.Id == id);

        if (newAddition != null)
        {
            Addition.CountTypes countType = EnumControl.GetEnumValueByName<Addition.CountTypes>(countTypeName);
            var category = DataControl.unitOfWork.CategoryRepository.GetAll().FirstOrDefault(c => c.Name == categoryname);
            var addition = this.AllAdditions.FirstOrDefault(a => a.Id == id);
            newAddition.Name = name;
            addition.Name = name;
            newAddition.Price = float.Parse(price);
            addition.Price = float.Parse(price);
            newAddition.Count = int.Parse(count);
            addition.Count = int.Parse(count);
            newAddition.CountType = countType;
            addition.CountType = countType;
            newAddition.CategoryId = category.Id;
            addition.CategoryId = category.Id;
            string newPhotoPath = null;
            string fileName = Path.GetFileName(photo);
            if (fileName.Length != 0)
            {
                newPhotoPath = Path.Combine("/", "Photos", "Additions", fileName).Replace('\\', '/');
            }

            if (Path.GetFileName(newPhotoPath) != Path.GetFileName(newAddition.Photo) && newPhotoPath != null)
            {
                newAddition.Photo = newPhotoPath;
                addition.Photo = newPhotoPath;
            }
            else
            {
                photo = null;
            }

            DataControl.unitOfWork.AdditionRepository.Update(newAddition);
            DataControl.unitOfWork.Save();
            TCPControl.UpdateAddition(newAddition, photo);
        }
        else
        {
            MessageBox.Show("Додатку з таким ім'ям не знайдено!");
        }
    }

    public void DeleteAddition(string name)
    {
        Addition addition = DataControl.unitOfWork.AdditionRepository.GetAll().FirstOrDefault(a => a.Name == name);
        if (addition != null)
        {
            DataControl.unitOfWork.AdditionRepository.Delete(addition);
            DataControl.unitOfWork.Save();
            TCPControl.DeleteAddition(addition);
            this.AllAdditions.Remove(addition);
        }
        else
        {
            MessageBox.Show("Додатку з таким ім'ям не знайдено!");
        }
    }
}
