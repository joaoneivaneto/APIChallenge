using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIChallenge.Data
{
    public class Membros
    {

        public int id_empregado { get; set; }

        public Empregado empregado { get; set; }

        public int id_projeto { get; set; }

        public Projeto projeto { get; set; }

    }
}
