﻿using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Data.Dtos
{
    public class CreateVideoDto
    {
        [Required(ErrorMessage = "O campo Title é obrigatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Description é obrigatório")]
        [StringLength(1000, ErrorMessage = "O tamanho da Description não pode exceder 300 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Url é Obrigatório")]
        public string Url { get; set; }
    }
}
