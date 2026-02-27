namespace Coverage.Core.DTOs
{
    public class PolicyDTO
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string PolicyHolderName { get; set; } = string.Empty;
        public decimal PremiumAmount { get; set; }
        public decimal CoverageAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
