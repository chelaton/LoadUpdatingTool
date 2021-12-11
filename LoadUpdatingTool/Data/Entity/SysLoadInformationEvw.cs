namespace LoadUpdatingTool.Data.Entity
{
    public partial class SysLoadInformationEvw
    {
        public int Id { get; set; }
        public int? CurveNumber { get; set; }
        public decimal? EnergyMwh { get; set; }
        public int? NumberOfCustomers { get; set; }
        public decimal? PeakPower { get; set; }
        public decimal? ReactivePower { get; set; }
        public DateTime? InsertionTime { get; set; }
        public int? Gid { get; set; }
        public int? RwoGid { get; set; }
        public decimal? RwoCode { get; set; }
    }
}
