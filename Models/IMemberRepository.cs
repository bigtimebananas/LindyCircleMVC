using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public interface IMemberRepository
    {
        IEnumerable<Member> AllMembers { get; }
        IEnumerable<Member> GetMembers(bool activeOnly);
        Member GetMember(int memberID);
    }
}
