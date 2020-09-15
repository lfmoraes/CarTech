using System.ComponentModel;

namespace CarTech.ViewModel
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
