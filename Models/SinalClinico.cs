using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios.Models
{
    public class SinalClinico
    {
        public int SinalClinicoId { get; set; }

        public string Sinal { get; set; }

        public int RemedioId { get; set; }
    }
}