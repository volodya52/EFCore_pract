using EFCorePract.Data;
using EFCorePract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePract.Service
{
    public class UserService
    {
        private readonly AppDbContext _db=BaseDBService.Instance.Context;

        public void Add(Users user)
        {
            var _user = new Users
            {
                Login = user.Login,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = DateTime.Now
            };
            _db.Users.Add(_user);
            Commit();
        }

        public int Commit()=>_db.SaveChanges();
    }
}
