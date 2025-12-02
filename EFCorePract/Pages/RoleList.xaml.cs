using EFCorePract.Models;
using EFCorePract.Service;
using System;
using System.Collections.Generic;
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

namespace EFCorePract.Pages
{
    /// <summary>
    /// Логика взаимодействия для RoleList.xaml
    /// </summary>
    public partial class RoleList : Page
    {
        public RoleService service { get; set; } = new();
        public Role? current { get; set; } = null;
        public RoleList()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleForm(current));
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if(current != null)
            {
                NavigationService.Navigate(new RoleForm(current));
            }
            else
            {
                MessageBox.Show("Выберите роль");
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if(current != null)
            {
                if(MessageBox.Show("Хотите удалить роль?","Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите роль для удаления", "Удаление",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
