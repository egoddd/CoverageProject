namespace Coverage.Core.Enums
{
    public enum PolicyType
    {
        Health,
        Auto,
        Property
    }

    public enum PolicyStatus
    {
        Active,
        Expired,
        Canceled
    }

    public enum ClaimStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public enum PaymentStatus
    {
        Completed,
        Pending,
        Failed,
        Approved,
        Successful
    }

    public enum PaymentMethod
    {
        Crypto,
        BankTransfer,
        CreditCard,
        PayPal
    }

    public enum BillPaymentStatus
    { 

    }
}
