using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LindyCircleMVC.Models
{
    public class MockMemberRepository : IMemberRepository
    {
        public IEnumerable<Member> AllMembers =>
            new List<Member>
            {
                new Member{ MemberID = 1, FirstName = "Amanda", LastName = "Gerken", Inactive = false },
                new Member{ MemberID = 2, FirstName = "Michael", LastName = "Pipkin", Inactive = false },
                new Member{ MemberID = 3, FirstName = "Brienne", LastName = "Kordis", Inactive = false }
            };

        public Member GetMember(int memberID) {
            return AllMembers.FirstOrDefault(m => m.MemberID == memberID);
        }

        public IEnumerable<Member> GetMembers(bool activeOnly) {
            return AllMembers.Where(m => !m.Inactive || m.Inactive != activeOnly);
        }
    }
}
