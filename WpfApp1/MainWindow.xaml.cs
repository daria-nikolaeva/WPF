using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repositories repository = new Repositories();
       
        CostCheck costCheck;
        public MainWindow()
        {
          
            InitializeComponent();
            
            costCheck = new CostCheck(repository);
            costCheck.ValidChanged += checkValidness;

            repository.CollectionCanged += updateListView;
            repository.Add(new Phone() { Name="Телефон 1", Count=1, Cost=10000});
            repository.Add(new Phone() { Name="Телефон 2", Count=4, Cost=15000});
            repository.Add(new Phone() { Name="Телефон 3", Count=3, Cost=45000});
            repository.Add(new Phone() { Name="Телефон 4", Count=2, Cost=20000});

          

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
           
            button.Content = "Сохранить телефон";

            button = new Button();
            grid.Children.Add(button);
            button.MaxHeight = 50;
            button.MaxWidth = 120;
            Grid.SetColumn(button, 1);
            Grid.SetRow(button, 1);
          
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

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Phone phone;
            if ((repository.tryGetAt(listView.SelectedIndex,out phone)))
            {
                DataContext = phone;

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
    }
}
