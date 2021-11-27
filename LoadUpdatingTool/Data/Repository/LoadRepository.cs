using LoadUpdatingTool.Data.Entity;

namespace LoadUpdatingTool.Data.Repository
{
    public class LoadRepository : ILoadRepository
    {
        private readonly LoadContext _loadContext;
        public LoadRepository(LoadContext loadContext)
        {
            _loadContext = loadContext;
        }
        public ServicePoint GetServicePoint(int Id)
        {
            return _loadContext.ServicePoints.FirstOrDefault(x => x.Id == Id);
        }
        public IQueryable<ServicePoint> GetServicePointList()
        {
            return _loadContext.ServicePoints.AsQueryable();
        }
    }
}
