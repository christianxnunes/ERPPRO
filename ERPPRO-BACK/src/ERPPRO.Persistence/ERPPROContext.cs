using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Domain;
using Microsoft.EntityFrameworkCore;

namespace ERPPRO.Persistence
{
    public class ERPPROContext : DbContext
    {
        public ERPPROContext(DbContextOptions<ERPPROContext> options) : base(options) {}
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<NivelAcesso> NivelAcessos { get; set; }
        public DbSet<Comunicacao> Comunicacoes { get; set; }
    }
}