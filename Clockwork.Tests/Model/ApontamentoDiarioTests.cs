using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clockwork;
using System.Collections.Generic;

namespace Clockwork.Tests.Model
{
    [TestClass]
    public class ApontamentoDiarioTests
    {
        [TestMethod]
        public void CronogramaDoDiaEstaCompletoTest()
        {
            var cargaHoraria = new TimeSpan(8, 30, 0);
            var horasCompletas = new List<TimeSpan>() { new TimeSpan(4, 0, 0), new TimeSpan(3, 0, 0), new TimeSpan(1, 31, 0) };
            var horasIncompletas = new List<TimeSpan>() { new TimeSpan(3, 49, 0), new TimeSpan(1, 20, 0), new TimeSpan(0, 14, 0) };
            
            var apontamentoCompleto = new ApontamentoDiario(DateTime.Today, horasCompletas);
            var apontamentoIncompleto = new ApontamentoDiario(DateTime.Today, horasIncompletas);

            Assert.IsTrue(apontamentoCompleto.CronogramaDoDiaEstaCompleto(cargaHoraria));
            Assert.IsFalse(apontamentoIncompleto.CronogramaDoDiaEstaCompleto(cargaHoraria));
        }

        [TestMethod]
        public void CalculoHorasFaltantesTest()
        {
            var cargaHoraria = new TimeSpan(8, 30, 0);
            var horasCompletas = new List<TimeSpan>() { new TimeSpan(4, 0, 0), new TimeSpan(3, 0, 0), new TimeSpan(1, 31, 0) };
            var horasIncompletas = new List<TimeSpan>() { new TimeSpan(3, 49, 0), new TimeSpan(1, 20, 0), new TimeSpan(0, 14, 0) };
            
            var apontamentoCompleto = new ApontamentoDiario(DateTime.Today, horasCompletas);
            var apontamentoIncompleto = new ApontamentoDiario(DateTime.Today, horasIncompletas);
            
            Assert.AreEqual(new TimeSpan(0, 0, 0), apontamentoCompleto.HorasFaltantesParaCompletarCronograma(cargaHoraria));
            Assert.AreEqual(new TimeSpan(3, 7, 0), apontamentoIncompleto.HorasFaltantesParaCompletarCronograma(cargaHoraria));
        }
    }
}
