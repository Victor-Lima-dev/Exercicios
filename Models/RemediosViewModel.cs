using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios.Models
{
    public class RemediosViewModel
    {
        public List<Remedio> TodosRemedios { get; set; } = new List<Remedio>();

        public List<SinalClinico> TodosSinaisClinicos { get; set; } = new List<SinalClinico>();

        public List<Remedio> RemediosSelecionados { get; set; } 
    }
}