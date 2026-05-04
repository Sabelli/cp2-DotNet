using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2_DotNet.API.Models
{
    [Table("tb_avaliacao")]
    public class AvaliacaoEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do autor é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do autor deve ter entre 1 e 100 caracteres.")]
        [Column("a_autor")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "A nota é obrigatória.")]
        [Range(1, 10, ErrorMessage = "A nota deve ser um valor entre 1 e 10.")]
        [Column("a_nota")]
        public int Nota { get; set; }

        [StringLength(1000, ErrorMessage = "O comentário deve ter no máximo 1000 caracteres.")]
        [Column("a_comentario")]
        public string? Comentario { get; set; }

        [Column("a_dataavaliacao")]
        public DateTime DataAvaliacao { get; set; } = DateTime.UtcNow;
    }
}
