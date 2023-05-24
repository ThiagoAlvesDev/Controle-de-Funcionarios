using ControleDeFuncionarios.Data;
using ControleDeFuncionarios.Models;

namespace ControleDeFuncionarios.Repositorio
{
    public class CadastroRepositorio : ICadastroRepositorio
    {

        private readonly BancoContext _bancoContext;
       
        public CadastroRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ColaboradorModel Adicionar(ColaboradorModel colaborador)
        {
            _bancoContext.Colaborador.Add(colaborador);
            _bancoContext.SaveChanges();
            return colaborador;
        }
    }
}
