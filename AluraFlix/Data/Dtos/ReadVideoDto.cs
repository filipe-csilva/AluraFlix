using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Data.Dtos
{
    public class ReadVideoDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
    }
}
