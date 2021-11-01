using System.ComponentModel.DataAnnotations;

namespace WashFua.Dtos
{
    public record CreateMamaFuaDto
    {
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}