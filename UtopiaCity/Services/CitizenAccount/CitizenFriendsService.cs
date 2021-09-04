using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Services.CitizenAccount
{
    /// <summary>
    /// Class to handle operations for <see cref="Friend"/>
    /// </summary>
    public class CitizenFriendsService
    {
        private readonly ApplicationDbContext _dbContext;

        public CitizenFriendsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets list of all user confirmed friend.
        /// </summary>
        /// <returns>List of all existing confirmed friend.</returns>
        public virtual List<AppUser> GetUserFriends(AppUser user)
        {
            var friendListId = (from users in _dbContext.AppUser
                                join friends in _dbContext.Friend on users.Id equals friends.FirstUserId
                                where users.Id == user.Id && friends.FriendsStatus == FriendsStatus.Confirmed
                                select friends.SecondUserId)
                    .Union(from users in _dbContext.AppUser
                           join friends in _dbContext.Friend on users.Id equals friends.SecondUserId
                           where users.Id == user.Id && friends.FriendsStatus == FriendsStatus.Confirmed
                           select friends.FirstUserId);

            var friendList = (from users in _dbContext.AppUser
                              where (friendListId).Contains(users.Id)
                              select users).ToList();
            return friendList;
        }

        /// <summary>
        /// Gets list of all people waiting to approve by user.
        /// </summary>
        /// <returns>List of all existing waiting to approve people.</returns>
        public virtual List<AppUser> GetUserWaitingApproveToFriends(AppUser user)
        {
            var waitingListId = (from users in _dbContext.AppUser
                                 join friends in _dbContext.Friend on users.Id equals friends.SecondUserId
                                 where users.Id == user.Id && friends.FriendsStatus == FriendsStatus.Waiting
                                 select friends.FirstUserId);

            var waitingList = (from users in _dbContext.AppUser
                               where (waitingListId).Contains(users.Id)
                               select users).ToList();
            return waitingList;
        }

        /// <summary>
        /// Gets list of all people rejected by user.
        /// </summary>
        /// <returns>List of all existing rejected people.</returns>
        public virtual List<AppUser> GetUserRejectedAplicationsToFriends(AppUser user)
        {
            var rejectedListId = (from users in _dbContext.AppUser
                                  join friends in _dbContext.Friend on users.Id equals friends.FirstUserId
                                  where users.Id == user.Id && friends.FriendsStatus == FriendsStatus.Rejected
                                  select friends.SecondUserId)
                                            .Union(from users in _dbContext.AppUser
                                                   join friends in _dbContext.Friend on users.Id equals friends.SecondUserId
                                                   where users.Id == user.Id && friends.FriendsStatus == FriendsStatus.Rejected
                                                   select friends.FirstUserId);

            var rejectedList = (from users in _dbContext.AppUser
                                where (rejectedListId).Contains(users.Id)
                                select users).ToList();
            return rejectedList;
        }

        /// <summary>
        /// Method to add new friendship.
        /// </summary>
        /// <param name="friendship">Friendship to add.</param>
        /// <returns>Task to await for.</returns>
        public virtual async Task AddFriendship(Friend friendship)
        {
            _dbContext.Add(friendship);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to add new friendship.
        /// </summary>
        /// <param name="user">Current user.</param>
        /// <param name="userFriend">User to friend.</param>
        /// <returns>Task to await for.</returns>
        public virtual Friend GetFriendship(AppUser user, AppUser userFriend)
        {
            var friendship = (from friends in _dbContext.Friend
                                     where
                                     (friends.FirstUser == user && friends.SecondUser == userFriend)
                                     || (friends.FirstUser == userFriend && friends.SecondUser == user)
                                     select friends).FirstOrDefault();
            return friendship;
        }

        /// <summary>
        /// Method to delete friendship.
        /// </summary>
        /// <param name="friendship">Friendship to delete.</param>
        /// <returns>Task to await for.</returns>
        public virtual async Task DeleteFriendship(Friend friendship)
        {
            _dbContext.Remove(friendship);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to accept friendship.
        /// </summary>
        /// <param name="friendship">Friendship accept and set FriendsStatus to confirmed.</param>
        /// <returns>Task to await for.</returns>
        public virtual async Task AcceptFriendship(Friend friendship)
        {
            friendship.FriendsStatus = FriendsStatus.Confirmed;
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method to refuse friendship.
        /// </summary>
        /// <param name="friendship">Friendship rejection and set FriendsStatus to rejected.</param>
        /// <returns>Task to await for.</returns>
        public virtual async Task RefuseFriendship(Friend friendship)
        {
            friendship.FriendsStatus = FriendsStatus.Rejected;
            await _dbContext.SaveChangesAsync();
        }

    }
}
