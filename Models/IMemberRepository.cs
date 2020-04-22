using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers(bool activeOnly);
        IList<SelectListItem> GetMemberList();
        IList<SelectListItem> GetTransferMemberList(int memberID);
        Member GetMember(int memberID);
        Member UpdateMember(Member member);
        Member AddMember(Member member);
        void DeleteMember(Member member);
    }
}
