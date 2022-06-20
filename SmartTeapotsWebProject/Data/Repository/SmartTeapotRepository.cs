using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Models;
using SmartTeapotsWebProject.Data.DBContexts;

namespace SmartTeapotsWebProject.Data.Repository
{
    public class SmartTeapotRepository : IAllSmartTeapots
    {
        private readonly SmartTeapotsDbContext _dbContext;

        public SmartTeapotRepository(SmartTeapotsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SmartTeapot> SmartTeapots => _dbContext.SmartTeapots.ToList();

        public SmartTeapot GetSmartTeapotById(int teapotId) => _dbContext.SmartTeapots.FirstOrDefault(teapot => teapot.Id == teapotId)!;
    }
}
