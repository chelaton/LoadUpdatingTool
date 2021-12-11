namespace LoadUpdatingTool.Data.DTO
{
    public class CurveUpdate
    {
        public int Curve { get; set; }
        public int CustomersCount { get; set; }
        public decimal EnergyMWh { get; set; }
        public List<int> Identifications = new List<int> { };
        public List<string> VerificationErrors = new List<string> { };
    }
}
