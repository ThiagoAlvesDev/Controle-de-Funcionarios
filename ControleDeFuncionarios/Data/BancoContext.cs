using ControleDeFuncionarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeFuncionarios.Data
{
    public class BancoContext : DbContext
    {
       
        public DbSet<ColaboradorModel> Colaborador { get; set; }

        public DbSet<EmpresaModel> Empresa { get; set; }

        public DbSet<CargoModel> Cargo { get; set; }


        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(connectionString: "DataSource=ControleDeFuncionarios.db; Cache=Shared"); //Melhora o desempenho de compartilhamento
        //}
    }
}