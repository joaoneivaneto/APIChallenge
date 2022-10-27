using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIChallenge.Data
{
    public class Projeto
    {
        [Required]
        public int id_projeto { get; set; }

        [Required]
        public string nome { get; set; } 

        [Required]
        public DateTime data_de_criação { get; set; }

       
        public DateTime? data_temino { get; set; }

       
        public int gerente { get; set; }

        [JsonIgnore]
        public Empregado empregado { get; set; }

        public ICollection<Membro> membros { get; set; }
    }
}
