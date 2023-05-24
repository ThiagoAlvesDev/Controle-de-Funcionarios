using ControleDeFuncionarios.Models;

namespace ControleDeFuncionarios.Repositorio
{
    public interface ICadastroRepositorio
    {
        ColaboradorModel Adicionar(ColaboradorModel colaborador);
    }
}
