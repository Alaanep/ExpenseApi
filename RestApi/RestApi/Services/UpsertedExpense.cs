using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public record struct UpsertedExpense(bool IsNewlyCreated);
}