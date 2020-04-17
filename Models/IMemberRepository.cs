using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers(bool activeOnly);
        Member GetMember(int memberID);
    }
}
