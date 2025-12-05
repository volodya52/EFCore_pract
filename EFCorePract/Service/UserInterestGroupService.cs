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
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db=BaseDBService.Instance.Context;
        public static ObservableCollection<UserInterestGroup> UserInterestGroups { get; set; } = new( );
        public int Commit () => _db.SaveChanges( );

        public void Add(UserInterestGroup userInterestGroup)
        {
            var _userInterestGroup = new UserInterestGroup
            {
                InterestGroupId = userInterestGroup.InterestGroupId,
                
                UserId = userInterestGroup.UserId,
               
                IsModerator = userInterestGroup.IsModerator,
                JoinedAt = userInterestGroup.JoinedAt
            };
            _db.Add<UserInterestGroup>(_userInterestGroup);
            Commit( );
            UserInterestGroups.Add(_userInterestGroup);
        }

        public void GetAll ()
        {
            var userInterestGroups = _db.UsersInterestGroups
                .Include(ug => ug.User)
                .Include(ug => ug.InterestGroup)
                .ToList();

            UserInterestGroups.Clear();
            foreach (var group in userInterestGroups)
            {
                UserInterestGroups.Add(group);
            }
        }

        public List<UserInterestGroup> GetUserGroups(int userId)
        {
            return _db.UsersInterestGroups
                .Where(ug => ug.UserId == userId)
                .Include(ug => ug.InterestGroup)
                .ToList();
        }

        // Метод для получения групп пользователя в виде объектов InterestGroup
        public List<InterestGroup> GetUserInterestGroups(int userId)
        {
            return _db.UsersInterestGroups
                .Where(ug => ug.UserId == userId)
                .Include(ug => ug.InterestGroup)
                .Select(ug => ug.InterestGroup)
                .ToList();
        }
    }
}
