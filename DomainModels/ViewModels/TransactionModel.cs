using DomainModels.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.ViewModels
{
    [NotMapped]
    public class TransactionModel : Transaction
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
