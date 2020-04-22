using System.Collections.Generic;

namespace LindyCircleMVC.Models
{
    public interface IPunchCardRepository
    {
        IEnumerable<PunchCard> GetPunchCardsByMember(int memberID);
        PunchCard GetPunchCard(int punchCardID);
        PunchCard PurchasePunchCard(PunchCard punchCard);
        PunchCard TransferPunchCard(PunchCard punchCard);
        void DeletePunchCard(PunchCard punchCard);
        void DeletePunchCard(int punchCardID);
    }
}
