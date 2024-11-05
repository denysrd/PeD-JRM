using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeD_JRM.Models
{
    public class TipoIngrediente
    {
        public int Id_Tipo_Ingrediente { get; set; }

        public string Tipo_Ingrediente { get; set; }

        public string Descricao_Tipo_Ingrediente { get; set; }

        public bool Situacao { get; set; }

        public string Sigla { get; set; }
    }
}
