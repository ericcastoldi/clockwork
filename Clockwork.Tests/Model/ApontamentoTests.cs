using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clockwork;

namespace Clockwork.Tests.Model
{
    [TestClass]
    public class ApontamentoTests
    {
        [TestMethod]
        public void ConstrutorTest()
        {
            var apontamento = new Apontamento(DateTime.Today, new TimeSpan(3, 48, 0));

            Assert.AreEqual(DateTime.Today, apontamento.Data);
            Assert.AreEqual(new TimeSpan(3, 48, 0), apontamento.HorasLancadas);
        }
    }
}
