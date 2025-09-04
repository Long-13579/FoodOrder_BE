namespace Domain;

public enum OrderStatus
{
    WaitingForPayment = 0,
    Paid = 1,
    Preparing = 2,
    Delivering = 3,
    Completed = 4,
    Cancelled = 5
}
