using System.ComponentModel.DataAnnotations;

namespace Exo.WebApi.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}