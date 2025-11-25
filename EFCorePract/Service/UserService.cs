using EFCorePract.Data;
using EFCorePract.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePract.Service
{
    public class UserService
    {
        private readonly AppDbContext _db=BaseDBService.Instance.Context;

        public ObservableCollection<Users> Users { get; set; } = new();

        public UserService()
        {
            GetAll();
        }

        public void Add(Users user)
        {
            var _user = new Users
            {
                Login = user.Login,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                UserProfile=user.UserProfile,
                Role=user.Role
            };
            _db.Users.Add(_user);
            Commit();
        }

        public int Commit()=>_db.SaveChanges();

        public void GetAll()
        {
            var users = _db.Users
                .Include(s => s.UserProfile)
                .Include(s=>s.Role)
                .ToList( );
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public void Remove(Users users)
        {
            _db.Remove<Users>(users);
            if (Commit() > 0)
            {
                if(Users.Contains(users))
                    Users.Remove(users);
            }
        }
    }
}
