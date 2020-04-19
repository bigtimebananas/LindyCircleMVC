using LindyCircleMVC.Models;
using LindyCircleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LindyCircleMVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepository _memberRepository;

        public MemberController(IMemberRepository memberRepository) {
            _memberRepository = memberRepository;
        }

        public ViewResult List(bool activeOnly = true) {
            var membersListViewModel = new MembersListViewModel
            {
                Members = _memberRepository.GetMembers(activeOnly),
                ActiveStatus = activeOnly ? "Active members" : "All members"
            };
            ViewBag.Title = "Members";
            return View(membersListViewModel);
        }

        public IActionResult Details(int memberID) {
            var member = _memberRepository.GetMember(memberID);
            if (member == null)
                return NotFound();
            return View(member);
        }
    }
}