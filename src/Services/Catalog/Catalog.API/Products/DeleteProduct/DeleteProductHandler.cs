
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id)
        :ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    internal class DeleteProductCommandHandler
        (ILogger<DeleteProductCommandHandler> logger, IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProduct {@Command}", command);
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync();
            return new DeleteProductResult(true);
        }
    }
}
