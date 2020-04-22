using System;
using System.Collections.Generic;
using System.Text;

namespace Ryoji.Kitano.VetMaster.Dominio
{
    public class Prontuario
    {
        public int Id { get; set; }
        public string AnimalAtendido { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
        public string Observacoes { get; set; }
        public virtual Veterinario Veterinario { get; set; }

        public virtual List<Veterinario> Veterinarios { get; set; }
        public int IdVeterinario { get; set; }
        

    }
}
