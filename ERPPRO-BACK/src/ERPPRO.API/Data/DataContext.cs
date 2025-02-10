using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPPRO.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}