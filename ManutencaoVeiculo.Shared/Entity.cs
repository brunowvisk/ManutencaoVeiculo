using System;
using System.Collections.Generic;
using System.Text;

namespace ManutencaoVeiculo.Shared
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }

        public Entity()
        {
            //Id = id;
            DataRegistro = DateTime.Now;
        }

    }

}


