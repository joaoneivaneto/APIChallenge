

using System.Text.Json.Serialization;

namespace APIChallenge.DTO
{
    public class CreateEmpregadoDTO
    {
        [JsonIgnore]
        public int Id_Empregado { get; set; }
        public string Primeiro_Nome { get; set; }

        public string Ultimo_Nome { get; set; }

        public int Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
