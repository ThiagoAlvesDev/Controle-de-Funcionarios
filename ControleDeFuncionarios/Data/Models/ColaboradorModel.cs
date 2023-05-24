namespace ControleDeFuncionarios.Models
{
    public class ColaboradorModel
    {
        public int Id { get; set; }
        public string NomeColaborador { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime? DataDemissao { get; set; }
       
        public EmpresaModel Empresa { get; set; }

        public CargoModel Cargo { get; set; }
       

    }
}
