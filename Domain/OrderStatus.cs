namespace Domain;

public enum OrderStatus
{
    WaitingForPayment,
    Paid,
    Preparing,
    Delivering,
    Completed,
    Cancelled
}
