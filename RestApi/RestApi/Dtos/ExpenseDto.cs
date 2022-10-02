using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Dtos
{
    public record ExpenseDto
    {
        public Guid Id {get; init;}
        public string Description { get; init;}
        public string Category { get; init;}
        public decimal Amount { get; init;}
        public DateTimeOffset Date { get; init;}
    }
}