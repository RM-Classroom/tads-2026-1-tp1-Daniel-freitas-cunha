namespace Trabalho_Daniel_Locadora_veiculo.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string? Modelo { get; set; }
        public int Ano { get; set; }
        public double Quilometragem { get; set; }

        public int FabricanteId { get; set; }
        public Fabricante? Fabricante { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
