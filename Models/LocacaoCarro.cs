using System;

namespace Trabalho_Daniel_Locadora_veiculo.Models
{
    public class LocacaoCarro
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo? Veiculo { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public double KmInicial { get; set; }
        public double KmFinal { get; set; }

        public decimal ValorDiaria { get; set; }
        public decimal ValorTotal { get; set; }
    }

}
