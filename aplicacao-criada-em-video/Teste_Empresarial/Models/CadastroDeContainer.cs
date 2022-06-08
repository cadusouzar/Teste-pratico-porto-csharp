using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Empresarial.Models
{
    public class CadastroDeContainer
    {
        [Key]
        public int ContainerID { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage ="Preencha o nome corretamente")]
        [DisplayName ("Nome do cliente")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Preencha o numero do container corretamente")]
        [RegularExpression("^[A-Za-z]{4}[0-9]{7}$", ErrorMessage= "Preencha o campo corretamente (4 Letras e 7 Numeros)" )]
        [DisplayName("Numero do container")]
        public string ContainerNumber { get; set; }

        [DisplayName("Tipo do container")]
        [Required(ErrorMessage = "Selecione o tipo do container corretamente")]
        public ContainerType Type { get; set; }

        [DisplayName("Status do container")]
        [Required(ErrorMessage = "Selecione o status do container corretamente")]
        public ContainerStatus Status { get; set; }

        [DisplayName("Categoria do container")]
        [Required(ErrorMessage = "Selecione a categoria do container corretamente")]
        public ContainerCategory Category { get; set; }

        public ICollection<MovimentacaoDeContainer> movimentacaoDeContainers { get; set; }
    }
    public enum ContainerType : int
    {
        TYPE20 = 0,
        TYPE40 = 1
    }
    public enum ContainerStatus : int
    {
        Empty = 0,
        Full = 1
    }
    public enum ContainerCategory : int
    {
        Importation = 0,
        Exportation = 1
    }
}
