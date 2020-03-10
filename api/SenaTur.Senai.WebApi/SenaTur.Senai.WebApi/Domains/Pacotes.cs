using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Domains
{
    [Table("Jogos")]
    public class Pacotes
    {

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPacote { get; set; }

        [Column(TypeName = "VARCHAR(150)")]

        //IDPacote,NomePacote,Descricao,DataIda,DataVolta,Valor,Ativo e NomeCidade
    }
}
