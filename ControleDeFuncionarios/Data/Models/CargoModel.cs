namespace ControleDeFuncionarios.Models
{
    public class CargoModel
    {
        public int Id { get; set; }
        public string Funcao { get; set; }
        public string Cbo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ColaboradorModel> Colaboradores { get; set; }
    }
}
