using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Empresarial.Models
{
    public class MovimentacaoDeContainer
    {
        [Key]
        public int MovementID { get; set; }

        [Required(ErrorMessage = "Escolha o numero do container")]
        public string ContainerNumber { get; set; }

        [Required(ErrorMessage ="Escolha corretamente o tipo de movimento")]
        [DisplayName("Tipo de movimento gerado")]
        public TypeOfMovement TypeOfMovement { get; set; }

        [Required(ErrorMessage = "Escolha corretamente a data do movimento")]
        [DisplayName("Data inicial")]
        public DateTime InitialDate { get; set; }

        [Required(ErrorMessage = "Escolha corretamente a data do movimento")]
        [DisplayName("Data final")]
        public DateTime FinalDate { get; set; }

        public CadastroDeContainer CadastroDeContainer { get; set; }

        [NotMapped]
        public SelectList Containers { get; set; }

    }
    public enum TypeOfMovement: int
    {
        Embarque = 0, 
        Descarga = 1,
        GateIn = 2,
        GateOut = 3,
        Reposicionamento = 4,
        Pesagem = 5,
        Scanner = 6
    }
}
