namespace LoadUpdatingTool.Data.DTO
{
    public class CurveUpdate
    {
        public int Curve { get; set; }
        public int CustomersCount { get; set; }
        public decimal EnergyMWh { get; set; }
        public int Identifications { get; set; }
        public List<string> VerificationErrors = new List<string> { };
    }
}
