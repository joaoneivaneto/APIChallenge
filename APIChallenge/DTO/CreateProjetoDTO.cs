

using System;
using System.Text.Json.Serialization;

namespace APIChallenge.DTO
{
    public class CreateProjetoDTO
    {
        [JsonIgnore]
        public int Id_Projeto { get; set; }
        public string Nome { get; set; }

        public DateTime Data_De_Criação { get; set; } = DateTime.Now;

        public DateTime? Data_Termino { get; set; }

        public int Gerente { get; set; }
    }
}
