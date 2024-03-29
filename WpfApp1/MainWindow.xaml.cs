﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Resources;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repositories repository = new Repositories();
       
        Checker checker;
        public MainWindow()
        {
          
            InitializeComponent();


           
            
            
            checker= new Checker(repository);
            checker.ValidChanged += checkValidness;

            repository.CollectionCanged += updateListView;

            Phone phone = new Phone() { Name="te",Count=1,Cost=1000};
            List<System.ComponentModel.DataAnnotations.ValidationResult> errors = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            ValidationContext context = new ValidationContext(phone);
            if(!Validator.TryValidateObject(phone, context, errors, true))
            {
                string message = "";
                foreach(var error in errors)
                {
                    message += error.ErrorMessage + '\n';
                }
                MessageBox.Show(message);
            }
            //repository.Add(new Phone() { Name="Телефон 1", Count=1, Cost=10000});
            //repository.Add(new Phone() { Name="Телефон 2", Count=4, Cost=15000});
            //repository.Add(new Phone() { Name="Телефон 3", Count=3, Cost=45000});
            //repository.Add(new Phone() { Name="Телефон 4", Count=2, Cost=20000});

            //repository.SaveToXML("phones.xml");

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Button button = new Button();
            grid.Children.Add(button);
            button.MaxHeight = 50;
            button.MaxWidth = 120;
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 0);
            button.Click += Button_Click;
            TextBlock text = new TextBlock();
            text.Text= "Добавить телефон";
            button.Content = text;


            button = new Button();
            grid.Children.Add(button);
            button.MaxHeight = 50;
            button.MaxWidth = 120;
            Grid.SetColumn(button, 1);
            Grid.SetRow(button, 0);
            button.Click += Button_Click_1;
            button.Content = "Удалить телефон";

            button = new Button();
            grid.Children.Add(button);
            button.MaxHeight = 50;
            button.MaxWidth = 120;
            Grid.SetColumn(button, 0);
            Grid.SetRow(button, 1);
            button.Click += Button_Click_2;
            button.Content = "Загрузить картинку";

            button = new Button();
            grid.Children.Add(button);
            button.MaxHeight = 50;
            button.MaxWidth = 120;
            Grid.SetColumn(button, 1);
            Grid.SetRow(button, 1);
            button.Template = (ControlTemplate)FindResource("buttonTemplate");
            button.Content = "Загрузить из файла";

           
            

            docPanel.Children.Add(grid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Phone newPhone = new Phone() { Name = "Новый телефон", Count = 6, Cost = 5000 };
            repository.Add(newPhone);
           

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           if(listView.SelectedIndex >= 0)
            {
                repository.RemoveAt(listView.SelectedIndex);
                
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedIndex >= 0)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Images(*.jpg;*.jpeg;*bmp;*gif;*png)|*.jpg;*.jpeg;*bmp;*gif;*png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string soursePath = openFileDialog.FileName;
                   
                    string newPath = "images/"+openFileDialog.SafeFileName;
                    if (!Directory.Exists("images /"))
                    {
                        Directory.CreateDirectory("images /");
                    }
                    while (File.Exists(newPath))
                    {
                        string[] arr = newPath.Split('.');
                        arr[arr.Length-2] = arr[arr.Length-2]+"1";
                        newPath = string.Join(".", arr);
                    }
                    File.Copy(soursePath,newPath);

                    Phone phone;
                    if(!repository.tryGetAt(listView.SelectedIndex, out phone))
                    {
                        return;
                    }
                    phone.Image = newPath;
                    image.Source = phone.ImageSourse;

                }
               
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Phone phone;
            if ((repository.tryGetAt(listView.SelectedIndex,out phone)))
            {
                DataContext = phone;
                image.Source = phone.ImageSourse;
            }
           

        }

        private void updateListView(ArrayList phones)
        {
            listView.ItemsSource = null;
            listView.ItemsSource = phones;
        }

        private void checkValidness(bool validness)
        {
            if (validness == true)
            {
                textBox.Text = "Присутствуют и дешевые и дорогие";

            }
            else
            {
                textBox.Text = "Отсутствуют дешевые или дорогие";
            }
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
           
         IEnumerable<Phone> result = from phone in repository.getPhones().Cast<Phone>()
                                     select phone;

            IEnumerable<Phone> newResult=result
                .Where<Phone>(phone => { return phone.Cost > 10000; })
                .ToArray<Phone>();
            listView.ItemsSource = newResult;

        }
        private bool filter(Phone phone)
        {
            return phone.Cost > 10000;
        }
    }
}
