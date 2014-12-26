using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.Model
{
    public sealed class Apontamento
    {
        public DateTime Data { get; private set; }
        public TimeSpan HorasLancadas { get; private set; }
        
        public Apontamento(DateTime data, TimeSpan horas)
        {
            Data = data;
            HorasLancadas = horas;
        }
    }
}
