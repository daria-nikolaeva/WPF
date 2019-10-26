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
        public MainWindow()
        {
            InitializeComponent();

            ArrayList phones = new ArrayList();
            phones.Add(new Phone() { Name="Телефон 1", Count=1, Cost=10000});
            phones.Add(new Phone() { Name="Телефон 2", Count=4, Cost=15000});
            phones.Add(new Phone() { Name="Телефон 3", Count=3, Cost=45000});
            phones.Add(new Phone() { Name="Телефон 4", Count=2, Cost=20000});
            listView.ItemsSource = phones;
        }
    }
}
