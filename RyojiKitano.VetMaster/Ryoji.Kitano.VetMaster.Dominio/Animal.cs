using System;
using System.Collections.Generic;
using System.Text;

namespace Ryoji.Kitano.VetMaster.Dominio
{
    public class Animal
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Raça { get; set; }
        public string NomeDoDono { get; set; }

        public virtual Veterinario Veterinario { get; set; }
        public int IdVeterinario {get; set;}
    }
}
