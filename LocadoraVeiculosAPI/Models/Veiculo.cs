using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculosAPI.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }

        [Required]
        public int AnoFabricacao { get; set; }

        [Required]
        public decimal Quilometragem { get; set; }

        [Required]
        public int FabricanteId { get; set; }
        [ForeignKey("FabricanteId")]
        public virtual Fabricante Fabricante { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Aluguel> Alugueis { get; set; }
    }
}