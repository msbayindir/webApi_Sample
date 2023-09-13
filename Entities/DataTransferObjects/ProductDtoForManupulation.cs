using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public record ProductDtoForManupulation
    {
        [Required(ErrorMessage ="Name is required field")]
        [MinLength(2,ErrorMessage ="Min Length is must be 2")]
        [MaxLength(20,ErrorMessage ="Mam Length is must be 20")]
        public String ProductName { get; init; }
        [Required(ErrorMessage = "Price is required field")]
        [Range(10,1000,ErrorMessage ="10-1000")]
        public decimal Price { get; init; }
    }
}

