using LindyCircleMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LindyCircleMVC.ViewModels
{
    public class PunchCardTransferViewModel
    {
        public PunchCard PunchCard { get; set; }
        public Member CurrentMember { get; set; }
        public IList<SelectListItem> TransferMembers { get; set; }
    }
}
