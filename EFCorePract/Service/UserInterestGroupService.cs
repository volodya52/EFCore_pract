using EFCorePract.Data;
using EFCorePract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePract.Service
{
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db=BaseDBService.Instance.Context;

        public void Add(UserInterestGroup userInterestGroup)
        {
            var _userInterestGroup = new UserInterestGroup
            {
                InterestGroupId = userInterestGroup.InterestGroupId,
                InterestGroup = userInterestGroup.InterestGroup,
                UserId = userInterestGroup.UserId,
                User = userInterestGroup.User,
                IsModerator = userInterestGroup.IsModerator,
                JoinedAt = userInterestGroup.JoinedAt
            };
            _db.Add<UserInterestGroup>(_userInterestGroup);
            _db.SaveChanges();
        }
    }
}
