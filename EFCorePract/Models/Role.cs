using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePract.Models
{
    public class Role:ObservableObject
    {
        private int _id;
        public int Id
        {
            get=>_id;
            set => SetProperty(ref _id, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private ObservableCollection<Users> _users;
        public ObservableCollection<Users> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
    }
}
