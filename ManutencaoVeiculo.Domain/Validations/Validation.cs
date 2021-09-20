using System;
using System.Collections.Generic;
using System.Text;

namespace ManutencaoVeiculo.Domain.Validations
{
    public class Validation
    {
        public bool Valido { get; set; }
        public string Message { get; set; }
        public object Dado { get; set; }
    }
}
