using BuildingBlocks.CQRS;

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;

public record DeleteOrderResult(bool IsSuccess);
