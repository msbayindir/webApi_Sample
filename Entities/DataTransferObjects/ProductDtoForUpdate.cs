using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record ProductDtoForUpdate:ProductDtoForManupulation
    {
        [Required]
        public int Id { get; init; }

        
    }
}

