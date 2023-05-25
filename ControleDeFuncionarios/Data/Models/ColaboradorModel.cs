using System.ComponentModel.DataAnnotations;

namespace ControleDeFuncionarios.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string NomeColaborador { get; set; }
      
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string Cpf { get; set; }
      
        [Required(ErrorMessage = "O campo Matrícula é obrigatório.")]
        public string Matricula { get; set; } 

        [Required(ErrorMessage = "O campo Data de Admissão é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime? DataAdmissao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataDemissao { get; set; }

        public EmpresaModel Empresa { get; set; }

        public CargoModel Cargo { get; set; }


    }
}
