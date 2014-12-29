using Clockwork;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork
{
    public sealed class Cronograma
    {
        public IImmutableList<Apontamento> Apontamentos { get; private set; }
        private readonly TimeSpan CargaHorariaPadrao = new TimeSpan(8, 30, 0);
        private readonly CronogramaJson _json;

        public Cronograma()
        {
            _json = new CronogramaJson();

            var cronograma = _json.CarregarCronograma();
            this.Apontamentos = cronograma.Apontamentos;
        }

        public Cronograma(IList<Apontamento> apontamentos)
        {
            _json = new CronogramaJson();

            if (apontamentos == null
                || apontamentos.Count == 0)
            {
                this.Apontamentos = ImmutableList.Create<Apontamento>();
            }
            else
            {
                this.Apontamentos = ImmutableList.CreateRange(apontamentos);
            }
        }

        public Cronograma LancarApontamento(Apontamento apontamento)
        {
            var apontamentos = Apontamentos.Add(apontamento);
            var cronograma = new Cronograma(apontamentos.ToList());

            _json.Salvar(cronograma);

            return cronograma;
        }

        public IImmutableList<ApontamentoDiario> ApontamentosIncompletos()
        {
            var diasApontados = from apontamento in Apontamentos
                                group apontamento.HorasLancadas by apontamento.Data into apontamentosPorData
                                select new ApontamentoDiario(apontamentosPorData.Key, apontamentosPorData.ToList());

            var apontamentosIncompletos = new List<ApontamentoDiario>();
            foreach (var dia in diasApontados)
            {
                if (!dia.CronogramaDoDiaEstaCompleto(this.CargaHorariaPadrao))
                {
                    apontamentosIncompletos.Add(dia);
                }
            }

            return ImmutableList.CreateRange(apontamentosIncompletos);
        }
    }
}
