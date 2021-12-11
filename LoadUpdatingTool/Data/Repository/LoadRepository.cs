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
        public IQueryable<TeeServicePointEvw> GetAllServicePoints()
        {
            return _loadContext.TeeServicePointEvws.AsQueryable();
        }

        public IQueryable<SysLoadInformationEvw> GetAllSysLoads()
        {
            return _loadContext.SysLoadInformationEvws.AsQueryable();
        }

        public IQueryable<TeeLoadInformationEvw> GetAllTeeLoads()
        {
            return _loadContext.TeeLoadInformationEvws.AsQueryable();
        }

        public void InsertTeeLoads(ICollection<TeeLoadInformationEvw> teeLoadInformationList)
        {
            _loadContext.TeeLoadInformationEvws.AddRange(teeLoadInformationList);
            _loadContext.SaveChanges();
        }
        public void UpdateSysLoads(ICollection<SysLoadInformationEvw> sysLoadInformationList)
        {
            _loadContext.SysLoadInformationEvws.UpdateRange(sysLoadInformationList);
            _loadContext.SaveChanges();
        }
        public void InsertSysLoads(ICollection<SysLoadInformationEvw> sysLoadInformationList)
        {
            _loadContext.SysLoadInformationEvws.AddRange(sysLoadInformationList);
            _loadContext.SaveChanges();
        }

        public void UpdateServicePoints(ICollection<TeeServicePointEvw> servicePointList)
        {
            _loadContext.TeeServicePointEvws.UpdateRange(servicePointList);
            _loadContext.SaveChanges();
        }

        public int DeleteAllTeeLoads()
        {
            var all = _loadContext.TeeLoadInformationEvws.ToList();
            _loadContext.RemoveRange(all);
            _loadContext.SaveChanges();
            return all.Count;
        }

    }
}
