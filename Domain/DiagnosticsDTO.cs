using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class DiagnosticsDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Operation { get; set; }
        public int? Results { get; set; }
        public DateTime? Created { get; set; }
    }
}
