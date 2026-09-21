using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculosAPI.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}