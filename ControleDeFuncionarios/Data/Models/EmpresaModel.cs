namespace ControleDeFuncionarios.Models
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }

        public ICollection<ColaboradorModel> Colaboradores { get; set; }

    }
}
