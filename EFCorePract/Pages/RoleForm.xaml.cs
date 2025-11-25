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
    /// Логика взаимодействия для RoleForm.xaml
    /// </summary>
    public partial class RoleForm : Page
    {
        Role _role = new();
        RoleService service=new();
        bool isEdit = false;

        public RoleForm(Role? role=null)
        {
            InitializeComponent();
            if(role != null)
            {
                service.LoadRelation(role, "Users");
                _role=role;
                isEdit = true;
            }
            DataContext = _role;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if(isEdit)
                service.Commit();
            else
                service.Add(_role);
            Back(sender, e);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
