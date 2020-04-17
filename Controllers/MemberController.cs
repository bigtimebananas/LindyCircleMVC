using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ViewResult Index(bool activeOnly = false) {
            var membersIndexViewModel = new MembersIndexViewModel
            {
                Members = _memberRepository.GetMembers(activeOnly),
                ActiveStatus = activeOnly ? "Active members" : "All members"
            };
            return View(membersIndexViewModel);
        }
    }
}