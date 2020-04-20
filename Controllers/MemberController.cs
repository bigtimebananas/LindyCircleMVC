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
                ActiveOnly = activeOnly
            };
            ViewBag.Title = "Members";
            return View(membersListViewModel);
        }

        public IActionResult GetPartial(bool activeOnly) {
            var membersListViewModel = new MembersListViewModel
            {
                Members = _memberRepository.GetMembers(activeOnly),
                ActiveOnly = activeOnly
            };
            return PartialView("_MemberList", membersListViewModel);
        }

        public IActionResult Details(int id) {
            var member = _memberRepository.GetMember(id);
            if (member == null)
                return RedirectToAction("List", "Member");
            ViewBag.Title = member.FirstLastName;
            return View(member);
        }
    }
}