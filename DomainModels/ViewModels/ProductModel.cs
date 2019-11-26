using DomainModels.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.ViewModels
{
    [NotMapped]
    public class ProductModel : Product
    {
        public IFormFile file { get; set; }
    }
}
