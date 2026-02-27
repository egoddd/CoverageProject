namespace Coverage.Core.DTOs
{
    public class RejectClaimDTO
    {
        public int ClaimId { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
