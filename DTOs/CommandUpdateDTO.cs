using System.ComponentModel.DataAnnotations;

namespace CommandsREST.DTOs
{
    public class CommandUpdateDTO
    {
        [Required]
        [MaxLength(250)]
        public string? HowTo { get; set; }

        [Required]
        public string? Line { get; set; }

        [Required]
        public string? Platform { get; set; }
    }
}