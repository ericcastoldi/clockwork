using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.Model
{
    public class Cronograma
    {
        public IList<Apontamento> Apontamentos { get; private set; }
        private const TimeSpan CargaHorariaPadrao = new TimeSpan(8, 30, 0);

        public Cronograma(IList<Apontamento> apontamentos)
        {
            Apontamentos = apontamentos;
        }

        public bool ApontamentosMensaisCompletos()
        {
            var apontamentosMesAtual = Apontamentos.Where(a => a.Data.Month == DateTime.Today.Month).ToList();
            return ApontamentosEstaoCompletos(apontamentosMesAtual);
        }

        public bool ApontamentosDaSemanaCompletos() 
        {
            var apontamentosSemanaAtual = new List<Apontamento>();

            var diaDaSemanaAtual = DateTime.Today.DayOfWeek;
            if (diaDaSemanaAtual == DayOfWeek.Monday) // Se hoje for segunda, verifica apenas os lançamentos de hoje. 
            {
                apontamentosSemanaAtual = Apontamentos.Where(a => a.Data == DateTime.Today).ToList();
            }
            else 
            {
                if (diaDaSemanaAtual > DayOfWeek.Monday) 
                {
                    var diferencaDeHojeParaSegunda = DayOfWeek.Monday - diaDaSemanaAtual;
                    var segundaFeira = DateTime.Today.AddDays(diferencaDeHojeParaSegunda);

                    apontamentosSemanaAtual = Apontamentos.Where(a => a.Data >= segundaFeira && a.Data <= DateTime.Today).ToList();
                }
            }
            
            return ApontamentosEstaoCompletos(apontamentosSemanaAtual);
        }

        public bool ApontamentosDoDiaCompletos() 
        { 
            var apontamentosMesAtual = Apontamentos.Where(a => a.Data == DateTime.Today).ToList();
            return ApontamentosEstaoCompletos(apontamentosMesAtual);
        }

        public bool ApontamentosCompletos() 
        { 
            return ApontamentosEstaoCompletos(Apontamentos);
        }

        private bool ApontamentosEstaoCompletos(IList<Apontamento> apontamentos)
        {
            return apontamentos.All(apontamento => apontamento.EstaLancadoEmCompletude(CargaHorariaPadrao));
        }
    }
}
