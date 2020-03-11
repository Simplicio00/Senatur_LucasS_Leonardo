using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [Required(ErrorMessage = "O titulo do tipo de usuario e obrigatorio!")]
        public string Titulo { get; set; }

        public List<Usuarios> IdUsuario { get; set; }

    }
}
