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
                InterestGroup=userInterestGroup.InterestGroup,
                UserId = userInterestGroup.UserId,
                User=userInterestGroup.User,
                IsModerator = userInterestGroup.IsModerator,
                JoinedAt = userInterestGroup.JoinedAt
            };
            _db.Add<UserInterestGroup>(_userInterestGroup);
            Commit( );
            UserInterestGroups.Add(_userInterestGroup);
        }

        public void GetAll ()
        {
            var interestGroup = _db.UsersInterestGroups
                .Include(u => u.User)
                .ThenInclude(g => g.UserInterestGroups)
                .ToList( );
            UserInterestGroups.Clear( );
            foreach (var group in interestGroup)
            {
                UserInterestGroups.Add(group);
            }
        }
    }
}
