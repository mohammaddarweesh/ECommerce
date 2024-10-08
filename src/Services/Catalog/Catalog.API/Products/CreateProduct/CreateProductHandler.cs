﻿namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(string Name, List<String> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Create Product Entity
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //TODO Save To Database
            session.Store(product);
            await session.SaveChangesAsync();
            //Return Result
            return new CreateProductResult(product.Id);
        }
    }
}
