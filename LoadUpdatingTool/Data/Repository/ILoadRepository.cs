using LoadUpdatingTool.Data.Entity;

namespace LoadUpdatingTool.Data.Repository
{
    public interface ILoadRepository
    {
        ServicePoint GetServicePoint(int Id);
        IQueryable<ServicePoint> GetServicePointList();
    }
}