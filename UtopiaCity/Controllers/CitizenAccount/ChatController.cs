using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CitizenAccount;

namespace UtopiaCity.Controllers.CitizenAccount
{
    /// <summary>
    /// Class represent work for chat between users
    /// </summary>
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly CitizensAccountService _citizensAccountService;
        private readonly ChatService _chatService;


        public ChatController(ApplicationDbContext context, UserManager<AppUser> userManager, CitizensAccountService citizensAccountService, ChatService chatService)
        {
            _context = context;
            _userManager = userManager;
            _citizensAccountService = citizensAccountService;
            _chatService = chatService;
        }

        public async Task<IActionResult> ShowChat(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            var userOpponentInTalk = await _citizensAccountService.GetUserById(id);

            ViewBag.UserTwoId = id;
            ViewBag.CurrentUser = currentUser.UserName;

            var talk = _chatService.GetTalkBetweenUsers(currentUser, userOpponentInTalk);
            if (talk is null)
            {
                Talk newTalk = new Talk()
                {
                    UserOneId = currentUser.Id,
                    UserTwoId = userOpponentInTalk.Id
                };
                _chatService.SaveTalk(newTalk);
                return View(_chatService.GetMessagesBeetwenUsers(newTalk));
            }
            else
            {
                return View(_chatService.GetMessagesBeetwenUsers(talk));
            }
        }

        public async Task<IActionResult> Create(string message, string userTwoId)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return NotFound();
            }
            var currentUser = await _userManager.GetUserAsync(User);
            var userOpponentInTalk = await _citizensAccountService.GetUserById(userTwoId);
            var talk = _chatService.GetTalkBetweenUsers(currentUser, userOpponentInTalk);
            
            Message newMessage = new Message()
            {
                Author = currentUser.UserName,
                Sender = currentUser,
                Text = message,
                Talk = talk
            };
            _chatService.SaveMessage(newMessage);
            return RedirectToRoute(new
            {
                controller = "Chat",
                action = "ShowChat",
                id = userTwoId
            });
        }
    }
}
