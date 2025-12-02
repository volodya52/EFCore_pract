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
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        public UserService service { get; set; }=new();
        public Users? user { get; set; } = null;
        
        public UserList()
        {
            InitializeComponent();
            
        }

        private void GoRole(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleList());
        }

        private void GoEditPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new UsersPage());
        }

        public void EditUser(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка");
                return;
            }

            NavigationService.Navigate(new UsersPage(user));
        }

        public void Delete(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Выберите элемент из списка");
                return;
            }

            if(MessageBox.Show("Вы действительно хотите удалить эту запись?","Удалить", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(user);
                MessageBox.Show("Запись удалена");
            }
        }

        private void GoGroupsList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupsList());
        }

        private void AddinGroup(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя");
            }
            else
            {
                NavigationService.Navigate(new UserInGroup(user));
            }
        }
    }
}
