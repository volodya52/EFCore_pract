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
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private UserService _userService = new();
        public Users _user = new();
        bool isEdit=false;
        public UsersPage(Users? _editUsers=null)
        {
            InitializeComponent();
            if(_editUsers != null)
            {
                _user = _editUsers;
                isEdit = true;
            }
            if (_user.UserProfile == null)
                _user.UserProfile = new( );
            DataContext = _user;
        }

        private void GoBack(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveUser(object sender, EventArgs e)
        {
            if (isEdit)
                _userService.Commit( );
            else               
                _userService.Add(_user);
            NavigationService.GoBack();



        }
    }
}
