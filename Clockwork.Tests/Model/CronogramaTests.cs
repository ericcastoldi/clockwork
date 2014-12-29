using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clockwork;
using System.Collections.Generic;
using Clockwork;

namespace Clockwork.Tests.Model
{
    [TestClass]
    public class CronogramaTests
    {
        [TestMethod]
        public void ApontamentosIncompletosTest()
        {
            var apontamentoCompleto = new Apontamento(DateTime.Today, new TimeSpan(8, 30, 0));
            var apontamentoCompletoFracionado1 = new Apontamento(DateTime.Today.AddDays(1), new TimeSpan(5, 0, 0));
            var apontamentoCompletoFracionado2 = new Apontamento(DateTime.Today.AddDays(1), new TimeSpan(3, 30, 0));

            var apontamentoIncompleto = new Apontamento(DateTime.Today, new TimeSpan(8, 20, 0));
            var apontamentoIncompletoFracionado1 = new Apontamento(DateTime.Today.AddDays(2), new TimeSpan(5, 0, 0));
            var apontamentoIncompletoFracionado2 = new Apontamento(DateTime.Today.AddDays(2), new TimeSpan(1, 30, 0));

            var cronogramaCompleto = new Cronograma(new List<Apontamento>() { apontamentoCompleto });
            var cronogramaCompletoFracionado = new Cronograma(new List<Apontamento>() { apontamentoCompletoFracionado1, apontamentoCompletoFracionado2 });

            var cronogramaIncompleto = new Cronograma(new List<Apontamento>() { apontamentoIncompleto });
            var cronogramaIncompletoFracionado = new Cronograma(new List<Apontamento>() { apontamentoIncompletoFracionado1, apontamentoIncompletoFracionado2 });

            var apontamentosCompletos = cronogramaCompleto.ApontamentosIncompletos();
            var apontamentosCompletosFracionados = cronogramaCompletoFracionado.ApontamentosIncompletos();

            var apontamentosIncompletos = cronogramaIncompleto.ApontamentosIncompletos();
            var apontamentosIncompletosFracionados = cronogramaIncompletoFracionado.ApontamentosIncompletos();

            Assert.AreEqual(0, apontamentosCompletos.Count);
            Assert.AreEqual(0, apontamentosCompletosFracionados.Count);
            Assert.AreEqual(1, apontamentosIncompletos.Count);
            Assert.AreEqual(1, apontamentosIncompletosFracionados.Count);
        }

        [TestMethod]
        public void LancarApontamentoTest()
        {
            var cronograma = new Cronograma();
            var contagemApontamentosAntesDoLancamento = cronograma.Apontamentos.Count;

            cronograma = cronograma.LancarApontamento(new Apontamento(DateTime.Today, new TimeSpan(5, 30, 0)));

            Assert.IsNotNull(cronograma);
            Assert.IsTrue(cronograma.Apontamentos.Count > contagemApontamentosAntesDoLancamento);
            Assert.AreEqual(contagemApontamentosAntesDoLancamento + 1, cronograma.Apontamentos.Count);
        }
    }
}
