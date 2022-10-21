using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIChallenge.Data
{
    public class Empregado
    {
        [Required]
        public int id_empregado { get; set;}

        [Required]
        public string primeiro_nome { get; set; }

        [Required]
        public string ultimo_nome { get; set; }

        [Required]
        public int telefone { get; set; }

        [Required]
        public string endereco { get; set; }

        [Required]
        public ICollection<Projeto> projetos { get; set; }

        public ICollection<Membros> membros { get; set; }


    }
}
