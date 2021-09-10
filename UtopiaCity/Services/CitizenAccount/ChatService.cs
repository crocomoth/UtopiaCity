using System.Linq;
using UtopiaCity.Controllers.CitizenAccount;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;

namespace UtopiaCity.Services.CitizenAccount
{
    public class ChatService
    {
        /// <summary>
        /// Class to handle operations for <see cref="ChatController"/> and for work whith <see cref="Message"/>
        /// </summary>
        private readonly ApplicationDbContext _dbContext;

        public ChatService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets <see cref="Talk"/>.
        /// </summary>
        /// <param name="currentUser">Current app user.</param>
        /// <param name="userTwo">User opponent for talk.</param>
        /// <returns>Talk beetwen users if it exists, otherwise null.</returns>

        public virtual Talk GetTalkBetweenUsers(AppUser currentUser, AppUser userTwo)
        {
            return _dbContext.Talks
               .FirstOrDefault(x => x.UserOne == currentUser && x.UserTwo == userTwo
                || x.UserOne == userTwo && x.UserTwo == currentUser);
        }

        /// <summary>
        /// Gets list messages beetwen users.
        /// </summary>
        /// <returns>List of all existing messages, otherwise null.</returns>
        public virtual IQueryable<Message> GetMessagesBeetwenUsers(Talk talk)
        {
            return _dbContext.Messages.Where(x => x.TalkId == talk.Id).OrderBy(x => x.When);
        }

        /// <summary>
        /// Save talk.
        /// </summary>
        public virtual void SaveTalk(Talk talk)
        {
            _dbContext.Add(talk);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Save incomming message.
        /// </summary>
        public virtual void SaveMessage(Message message)
        {
            _dbContext.Add(message);
            _dbContext.SaveChanges();
        }
    }    
}
