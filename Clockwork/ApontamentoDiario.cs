using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork
{
    public sealed class ApontamentoDiario 
    {
        public DateTime Data { get; private set; }
        public IList<Apontamento> Apontamentos { get; private set; }

        public ApontamentoDiario(DateTime data, IList<TimeSpan> horasApontadas)
        {
            if (horasApontadas == null
                || horasApontadas.Count == 0)
            {
                throw new ArgumentException("Argumento em estado inválido. A lista de horas apontadas está vazia ou não possui elementos.");
            }

            this.Data = data;
            this.Apontamentos = new List<Apontamento>();
            foreach (var hora in horasApontadas)
            { 
                this.Apontamentos.Add(new Apontamento(data, hora));
            }
        }

        public bool CronogramaDoDiaEstaCompleto(TimeSpan cronogramaDoDia) 
        {
            var totalHorasLancadas = TotalHorasLancadas();
            return (totalHorasLancadas.Hours == cronogramaDoDia.Hours && totalHorasLancadas.Minutes >= cronogramaDoDia.Minutes);
        }

        public TimeSpan HorasFaltantesParaCompletarCronograma(TimeSpan cronogramaDoDia)
        {
            var totalHorasLancadas = TotalHorasLancadas();
            if (totalHorasLancadas < cronogramaDoDia)
                return cronogramaDoDia - totalHorasLancadas;

            return new TimeSpan(0, 0, 0);
        }

        private TimeSpan TotalHorasLancadas()
        { 
            var totalHorasLancadas = default(TimeSpan);

            foreach (var apontamento in Apontamentos)
            {
                totalHorasLancadas += apontamento.HorasLancadas;
            }

            return totalHorasLancadas;
        }

    }
}
