using System.Linq;

namespace LindyCircleMVC.Models
{
    public class DefaultRepository : IDefaultRepository
    {
        private readonly LindyCircleDbContext _dbContext;
        public DefaultRepository(LindyCircleDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Default GetDefault(string defaultName) =>
            _dbContext.Defaults.FirstOrDefault(d => d.DefaultName.Equals(defaultName));

        public Default GetDefault(int defaultID) =>
            _dbContext.Defaults.Find(defaultID);

        public decimal GetDefaultValue(string defaultName) =>
            _dbContext.Defaults.FirstOrDefault(d => d.DefaultName.Equals(defaultName)).DefaultValue;

        public decimal GetDefaultValue(int defaultID) =>
            _dbContext.Defaults.Find(defaultID).DefaultValue;
    }
}
