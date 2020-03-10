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
        [Required(ErrorMessage = "O nome do pacote é obrigatorio!")]
        public string NomePacote { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatoria!")]
        public string Descricao { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage = "A data de Ida é obrigatoria!")]
        [DataType(DataType.Date)]
        public DateTime DataIda { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de Volta é obrigatoria!")]
        [DataType(DataType.Date)]
        public DateTime DataVolta { get; set; }

        [Column("Preco",TypeName = "DECIMAL (18,2)")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "E necessario informar o preço do pacote!")]
        public decimal Valor { get; set; }

        [Column("Ativo",TypeName = "Bit")]
        [Required(ErrorMessage = "E necessario informar se esta ativo")]
        public bool Ativo { get; set; }

        [Column("NomeCidade",TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "E necessario informar o Cidade!")]
        public string NomeCidade { get; set; }

    }
}
