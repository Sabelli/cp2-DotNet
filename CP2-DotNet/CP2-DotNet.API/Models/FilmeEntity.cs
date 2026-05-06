using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2_DotNet.API.Models
{
    [Table("tb_filme")]
    public class FilmeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "O título deve ter entre 1 e 200 caracteres.")]
        [Column("f_titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O ano de lançamento é obrigatório.")]
        [Range(1888, 2100, ErrorMessage = "Ano de lançamento inválido. Deve ser entre 1888 e 2100.")]
        [Column("f_anolancamento")]
        public int AnoLancamento { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O gênero deve ter entre 1 e 50 caracteres.")]
        [Column("f_genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória.")]
        [Range(1, 51420, ErrorMessage = "A duração deve ser entre 1 e 51420 minutos.")]
        [Column("f_duracao")]
        public int DuracaoMin { get; set; }

        [Required(ErrorMessage = "O diretor é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O diretor deve ter entre 1 e 100 caracteres.")]
        [Column("f_diretor")]
        public string Diretor { get; set; }
    }
}
