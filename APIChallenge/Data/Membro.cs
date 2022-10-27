using System.Text.Json.Serialization;

namespace APIChallenge.Data
{
    public class Membro
    {
        public int id_empregado { get; set; }
        [JsonIgnore]
        public Empregado empregado { get; set; }

        public int id_projeto { get; set; }
        [JsonIgnore]
        public Projeto projeto { get; set; }
    }
}
