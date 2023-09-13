using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Domain.Entities
{
    public class Rota
    {
        public int Id { get; private set; }

        public Guid IdRota { get; private set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public decimal? Valor { get; private set; } 
    }
}
