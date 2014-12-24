using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.Model
{
    public class Apontamento
    {
        public DateTime Data { get; private set; }
        public TimeSpan HorasLancadas { get; private set; }
        
        public Apontamento(DateTime data, TimeSpan horas)
        {
            Data = data;
            HorasLancadas = horas;
        }

        public bool EstaLancadoEmCompletude(TimeSpan cronogramaDiario) 
        {
            return cronogramaDiario.Hours == HorasLancadas.Hours
                && cronogramaDiario.Minutes == HorasLancadas.Minutes;
        }

        public TimeSpan HorasFaltantes(TimeSpan cronogramaDiario) 
        {
            if (EstaLancadoEmCompletude(cronogramaDiario))
            {
                return new TimeSpan(0, 0, 0);
            }
            
            return cronogramaDiario - HorasLancadas;
        }
    }
}
