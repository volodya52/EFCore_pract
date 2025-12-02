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
    /// Логика взаимодействия для UserInGroup.xaml
    /// </summary>
    public partial class UserInGroup : Page
    {
        public UserInterestGroupService service { get; set; } = new();
        public InterestGroupService service2 { get; set; } = new();
        public UserInterestGroup current2 { get; set; } = new();

        public InterestGroup current1 { get; set; } = new();

        public Users _users { get; set; } = new();

        public UserInGroup(Users users)
        {
            InitializeComponent();
            _users = users;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
