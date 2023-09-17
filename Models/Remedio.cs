using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios.Models
{
    public class Remedio
    {
         public int RemedioId { get; set; }

        public string NomeComercial { get; set; }

        public string PrincipioAtivo { get; set; }

        public string Dose { get; set; }

        public string ViaAdministracao { get; set; }

        public string ResumoBasico { get; set; }

        public string CategoriaFarmacologica { get; set; }

        public string Imagem { get; set; }

        public string EfeitosAdversos { get; set; }

        public string Indicacao { get; set; }

        public string? Contraindicacao { get; set; }

        public string? InteracoesFarmacologicas { get; set; }

        public List<Especie> Especies { get; set; } = new List<Especie>();

        public List<SinalClinico> SinaisClinicos { get; set; } = new List<SinalClinico>();
    }
}