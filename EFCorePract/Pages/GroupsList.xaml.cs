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
    /// Логика взаимодействия для GroupsList.xaml
    /// </summary>
    public partial class GroupsList : Page
    {
        public InterestGroupService service { get; set; } = new();

        public InterestGroup? current { get; set; } = null;

        public GroupsList()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupsPage());
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new GroupsPage(current));
            }
            else
            {
                MessageBox.Show("Выберите группу интересов");
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if(current == null)
            {
                MessageBox.Show("Выберите группу интересов для удаления");
            }
            else
            {
                if(MessageBox.Show("Удалить группу интересов?","Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                    MessageBox.Show("Группа интересов удалена");
                }
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
