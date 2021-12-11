namespace LoadUpdatingTool.Data.Entity
{
    public partial class TeeLoadInformationEvw
    {
        public int Id { get; set; }
        public DateTime? InsertionTime { get; set; }
        public decimal? PeakPower { get; set; }
        public int? NumberOfCustomers { get; set; }
        public decimal? ReactivePower { get; set; }
        public int? CurveNumber { get; set; }
        public decimal? EnergyMwh { get; set; }
        public decimal? PowerFactor { get; set; }
        public int? Gid { get; set; }
        public int? RwoGid { get; set; }
        public decimal? RwoCode { get; set; }
    }
}
