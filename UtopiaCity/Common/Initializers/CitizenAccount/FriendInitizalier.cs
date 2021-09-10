using System.Linq;
using UtopiaCity.Common.Interfaces;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Common.Initializers.CitizenAccount
{
    public class FriendInitizalier : ISubDbInitializer
    {
        public void ClearSet(ApplicationDbContext context)
        {
            if (!context.Friend.Any())
            {
                return;
            }

            context.RemoveRange(context.Friend.ToList());
            context.SaveChanges();
        }

        public void InitializeSet(ApplicationDbContext context)
        {
            if (context.Friend.Any())
            {
                return;
            }

            var friendship1 = new Friend
            {
               FirstUserId= "1",
               SecondUserId= "4",
                FriendsStatus=FriendsStatus.Confirmed
            };
            var friendship2 = new Friend
            {
                FirstUserId = "1",
                SecondUserId = "2",
                FriendsStatus = FriendsStatus.Confirmed
            };
            var friendship3 = new Friend
            {
                FirstUserId = "1",
                SecondUserId = "3",
                FriendsStatus = FriendsStatus.Waiting
            };
            var friendship4 = new Friend
            {
                FirstUserId = "2",
                SecondUserId = "4",
                FriendsStatus = FriendsStatus.Rejected
            };
            var friendship5 = new Friend
            {
                FirstUserId = "2",
                SecondUserId = "3",
                FriendsStatus = FriendsStatus.Waiting
            };


            context.AddRange(friendship1, friendship2, friendship3, friendship4, friendship5);
            context.SaveChanges();
        }
    }
}
