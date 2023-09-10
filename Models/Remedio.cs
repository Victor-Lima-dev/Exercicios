using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios.Models
{
    public class Remedio
    {
        public Guid Id { get; set; }

        public string NomeComercial { get; set; }

        public string PrincipioAtivo { get; set; }

        public string Dose { get; set; }

        public string ViaAdministracao { get; set; }

        public string CategoriaFarmacologica { get; set; }

        public string Imagem { get; set; }

        public List<SinalClinico> SinaisClinicos { get; set; }
    }
}