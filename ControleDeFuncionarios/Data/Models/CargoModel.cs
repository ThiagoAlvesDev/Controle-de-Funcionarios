using System.ComponentModel.DataAnnotations;

namespace ControleDeFuncionarios.Models
{
    public class CargoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Cargo é obrigatório.")]
        public string Funcao { get; set; }
        [Required(ErrorMessage = "O campo CBO é obrigatório.")]
        public string Cbo { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        public ICollection<ColaboradorModel> Colaboradores { get; set; }
    }
}
