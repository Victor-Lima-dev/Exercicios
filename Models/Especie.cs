using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios.Models
{
    public class Especie
    {
        public int EspecieId { get; set; }

        public string Nome { get; set; }

        public List<Remedio> Remedios { get; set; } = new List<Remedio>();
        
        public int RemedioId { get; set; }
    }
}