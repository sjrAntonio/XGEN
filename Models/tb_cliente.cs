using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_Teste.Models
{
    public class tb_cliente
    {
        [Key]
        public long ID_CLIENTE { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string NOME { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string EMAIL { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public required string TELEFONE { get; set; }
    }
}
