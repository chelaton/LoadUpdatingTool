using LoadUpdatingTool.Data.Entity;

namespace LoadUpdatingTool.Data.Repository
{
    public interface ILoadRepository
    {
        IQueryable<TeeServicePointEvw> GetAllServicePoints();
        IQueryable<SysLoadInformationEvw> GetAllSysLoads();
        IQueryable<TeeLoadInformationEvw> GetAllTeeLoads();
        void InsertTeeLoads(ICollection<TeeLoadInformationEvw> teeLoadInformationList);
        void UpdateSysLoads(ICollection<SysLoadInformationEvw> sysLoadInformationList);
        void InsertSysLoads(ICollection<SysLoadInformationEvw> sysLoadToInsert);
        void UpdateServicePoints(ICollection<TeeServicePointEvw> servicePointList);
        int DeleteAllTeeLoads();
    }
}