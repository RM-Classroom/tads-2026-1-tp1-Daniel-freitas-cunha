namespace Trabalho_Daniel_Locadora_veiculo.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public List<Veiculo> Veiculos { get; set; }
    }
}
