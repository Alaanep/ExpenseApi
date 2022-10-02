using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Services
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){

        }
        public DbSet<Expense>? _expenses{ get; set; }
        public DbSet<Income>? _incomes{ get; set; }  
    }
}