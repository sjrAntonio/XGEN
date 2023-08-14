using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_Teste.Models
{
    public class tb_endereco
    {
        [Key]
        public long ID_ENDERECO { get; set; }

        [Column(TypeName = "long")]
        public required long ID_CLIENTE { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public required string ENDERECO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string BAIRRO { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string CIDADE { get; set; }

        [Column(TypeName = "long")]
        public required long CEP { get; set; }

        [Column(TypeName = "char(2)")]
        public required string UF { get; set; }
    }
}
