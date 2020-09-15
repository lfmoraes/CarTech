using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarTech.Domain.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [NotNull]
        public string Descricao { get; set; }
    }
}
