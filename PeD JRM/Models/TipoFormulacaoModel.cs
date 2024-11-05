using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeD_JRM.Models
{

    public class TipoFormulacao
    {
        public int Id_Tipo_Formulacao { get; set; }
       
        public string Tipo_Formula { get; set; }

        public string Descricao_Formula { get; set; }
    }
}
