using System.ComponentModel.DataAnnotations;

namespace ControleDeFuncionarios.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Razão Social é obrigatório.")]
        public string RazaoSocial { get; set; }
        [Required(ErrorMessage = "O campo Nome Fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public string Cnpj { get; set; }  

        public ICollection<ColaboradorModel> Colaboradores { get; set; }

    }
}
