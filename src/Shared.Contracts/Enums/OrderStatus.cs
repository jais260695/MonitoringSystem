namespace Shared.Contracts.Enums;

public enum OrderStatus
{
    Pending = 1,

    InventoryReserved = 2,

    PaymentCompleted = 3,

    NotificationSent = 4,

    Completed = 5,

    Failed = 6
}