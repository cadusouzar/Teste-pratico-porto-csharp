using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Empresarial.Models
{
    public class Teste_EmpresarialContext : DbContext
    {
        public Teste_EmpresarialContext(DbContextOptions<Teste_EmpresarialContext> options) : base(options)
        {
            
        }
        public DbSet<CadastroDeContainer> CadastroDeContainers { get; set; }

        public DbSet<MovimentacaoDeContainer> MovimentacaoDeContainers { get; set; }

    }
}
