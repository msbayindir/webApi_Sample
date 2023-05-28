using System;
namespace Entities.DataTransferObjects
{
    public record ProductDtoForUpdate
    {
        public int Id { get; init; }
        public string ProductName { get; init; }
        public decimal Price { get; init; }
    }
}

