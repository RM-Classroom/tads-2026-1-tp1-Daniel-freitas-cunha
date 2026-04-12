using System.Collections.Generic;
namespace Trabalho_Daniel_Locadora_veiculo.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }

        public List<LocacaoCarro> Locacao { get; set; }
    }
}
