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
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        InterestGroup _interestGroup = new();
        InterestGroupService service = new();
        bool isEdit = false;
        public GroupsPage(InterestGroup? interestGroup=null)
        {
            InitializeComponent();
            if(interestGroup != null)
            {
                _interestGroup = interestGroup;
                isEdit = true;
            }
            DataContext = _interestGroup;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                service.Commit();
            else
                service.Add(_interestGroup);
            Back(sender, e);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
