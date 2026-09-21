using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculosAPI.Models
{
    public class Aluguel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataDevolucaoPrevista { get; set; }

        public DateTime? DataDevolucaoRealizada { get; set; }

        [Required]
        public decimal QuilometragemInicial { get; set; }

        public decimal? QuilometragemFinal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorDiaria { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ValorTotal { get; set; }

        [Required]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        [Required]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public virtual Veiculo Veiculo { get; set; }
    }
}