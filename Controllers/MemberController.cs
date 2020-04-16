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
        private readonly IAttendanceRepository _attendanceRepository;

        public MemberController(IMemberRepository memberRepository, IAttendanceRepository attendanceRepository) {
            _memberRepository = memberRepository;
            _attendanceRepository = attendanceRepository;
        }

        public ViewResult Index(bool activeOnly = false) {
            var membersIndexViewModel = new MembersIndexViewModel
            {
                Members = _memberRepository.GetMembers(activeOnly),
                Attendances = _attendanceRepository.AllAttendances,
                ActiveStatus = activeOnly ? "Active members" : "All members"
            };
            return View(membersIndexViewModel);
        }
    }
}