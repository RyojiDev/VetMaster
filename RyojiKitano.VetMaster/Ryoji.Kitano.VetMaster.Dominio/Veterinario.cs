using System;
using System.Collections.Generic;
using System.Text;

namespace Ryoji.Kitano.VetMaster.Dominio
{
    public class Veterinario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string AnimalAtendido { get; set; }

        public DateTime DataHoraAtendimento { get; set; }

        public int CRV { get; set; }

        public virtual List<Prontuario> Prontuarios { get; set; }
        public virtual List<Animal> Animais{
            get; set;}

    }
}
