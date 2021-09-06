using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.CitizenAccount;
using UtopiaCity.Services.CitizenAccount;

namespace UtopiaCity.Controllers.CitizenAccount
{
    [Authorize]
    public class CitizenFriendsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly CitizensAccountService _citizensAccountService;
        private readonly CitizenFriendsService _citizenFriendsService;

        public CitizenFriendsController(UserManager<AppUser> userManager, CitizensAccountService citizensAccountService, CitizenFriendsService citizenFriendsService)
        {
            _userManager = userManager;
            _citizensAccountService = citizensAccountService;
            _citizenFriendsService = citizenFriendsService;
        }

        public async Task<IActionResult> IndexFriends()
        {
            return View(_citizenFriendsService.GetUserFriends(await _userManager.GetUserAsync(User)));
        }

        public async Task<IActionResult> IndexWaiting()
        {
            return View(_citizenFriendsService.GetUserWaitingApproveToFriends(await _userManager.GetUserAsync(User)));
        }
        public async Task<IActionResult> IndexRejected()
        {
            return View(_citizenFriendsService.GetUserRejectedAplicationsToFriends(await _userManager.GetUserAsync(User)));
        }

        [HttpGet]
        public IActionResult FindUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                ViewBag.Message = "Enter User name value";
                return View(username);
            }

            if (_citizensAccountService.GetUserByUserName(username) is null)
            {
                ViewBag.Message = "User \"" + username + "\" not found";
                return View("FindUser", username);
            }
            return View("FindUserAsync", _citizensAccountService.GetUserByUserName(username));
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToFriendsListWaitingAsync(string id)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            var friendList = _citizenFriendsService.GetUserWaitingApproveToFriends(user);
            AppUser userToFriends = await _citizensAccountService.GetUserById(id);

            if (friendList.Contains(userToFriends))
            {
                return RedirectToAction(nameof(IndexFriends));
            }

            Friend friendship = new Friend
            {
                FirstUserId = user.Id,
                SecondUserId = userToFriends.Id,
                FriendsStatus = FriendsStatus.Waiting
            };
            await _citizenFriendsService.AddFriendship(friendship);
            return RedirectToAction(nameof(IndexFriends));
        }

        public async Task<IActionResult> DeleteUserFromFriends(string id)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            AppUser userFriendTodelete = await _citizensAccountService.GetUserById(id);
            var frindshipToDelete = _citizenFriendsService.GetFriendship(user, userFriendTodelete);
            if (frindshipToDelete is null)
            {
                return RedirectToAction(nameof(IndexFriends));
            }
            await _citizenFriendsService.DeleteFriendship(frindshipToDelete);
            return RedirectToAction(nameof(IndexFriends));
        }
        public async Task<IActionResult> AddToFriend(string id)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            AppUser userToAdd = await _citizensAccountService.GetUserById(id);
            var friendshipToConfirm = _citizenFriendsService.GetFriendship(user, userToAdd);
            if (friendshipToConfirm is null)
            {
                return RedirectToAction(nameof(IndexFriends));
            }
            await _citizenFriendsService.AcceptFriendship(friendshipToConfirm);
            return RedirectToAction(nameof(IndexFriends));
        }

        public async Task<IActionResult> RefuseFromFriendship(string id)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            AppUser userToRefuse = await _citizensAccountService.GetUserById(id);
            var refuseFrienship = _citizenFriendsService.GetFriendship(user, userToRefuse);
            if (refuseFrienship is null)
            {
                return RedirectToAction(nameof(IndexFriends));
            }
            await _citizenFriendsService.AcceptFriendship(refuseFrienship);
            return RedirectToAction(nameof(IndexFriends));
        }
    }
}