using HumanizadorDeCheques.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HumanizadorDeCheques.Tests
{
    [TestClass]
    public class HumanizadotTest
    {
        [TestMethod]
        [DataRow(0, "")]
        [DataRow(1, "um")]
        [DataRow(2, "dois")]
        [DataRow(3, "três")]
        [DataRow(4, "quatro")]
        [DataRow(5, "cinco")]
        [DataRow(6, "seis")]
        [DataRow(7, "sete")]
        [DataRow(8, "oito")]
        [DataRow(9, "nove")]
        public void Deve_Converter_Unidades_De_Real(double valorRecebido, string resultadoEsperado)
        {
            //Arrange
            Humanizador hv = new Humanizador();
            
            //Action
            string resultado = hv.HumanizarCheque(valorRecebido);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [DataRow(33, "trinta e três")]
        [DataRow(93, "noventa e três")]
        [DataRow(60, "sessenta")]
        [DataRow(10, "dez")]
        [DataRow(11, "onze")]
        [DataRow(12, "doze")]
        [DataRow(13, "treze")]
        [DataRow(15, "quinze")]
        [DataRow(17, "dezessete")]
        public void Deve_Converter_Dezenas_E_Unidades_De_Real(double valorRecebido, string resultadoEsperado)
        {
            //Arrange
            Humanizador hv = new Humanizador();

            //Action
            string resultado = hv.HumanizarCheque(valorRecebido);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        //[DataRow(133, "cento e trinta e três reais")]
        [DataRow(100, "cem reais")]
        [DataRow(1, "um real")]
        [DataRow(2, "dois reais")]
        [DataRow(10, "dez reais")]
        [DataRow(17, "dezessete reais")]
        [DataRow(20, "vinte reais")]
        [DataRow(30, "trinta reais")]
        [DataRow(21, "vinte e um reais")]
        [DataRow(45, "quarenta e cinco reais")]
        [DataRow(78, "setenta e oito reais")]
        [DataRow(103, "cento e três reais")]
        [DataRow(117, "cento e dezessete reais")]
        [DataRow(171, "cento e setenta e um reais")]
        [DataRow(193, "cento e noventa e três reais")]
        [DataRow(130, "cento e trinta reais")]
        [DataRow(170, "cento e setenta reais")]
        [DataRow(110, "cento e dez reais")]
        [DataRow(148, "cento e quarenta e oito reais")]
        [DataRow(161, "cento e sessenta e um reais")]
        [DataRow(200, "duzentos reais")]
        [DataRow(300, "trezentos reais")]
        [DataRow(710, "setecentos e dez reais")]
        [DataRow(613, "seiscentos e treze reais")]
        [DataRow(520, "quinhentos e vinte reais")]
        [DataRow(437, "quatrocentos e trinta e sete reais")]
        [DataRow(399, "trezentos e noventa e nove reais")]
        //[DataRow(9318901.81, "novecentos e trinta e um reais")]
        //[DataRow(1000000, "um milhão reais")]
        [DataRow(600, "seiscentos reais")]
        public void Deve_Converter_Centenas_Dezenas_E_Unidades_De_Real(double valorRecebido, string resultadoEsperado)
        {
            //Arrange
            Humanizador hv = new Humanizador();

            //Action
            string resultado = hv.HumanizarCheque(valorRecebido);

            //Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        //[DataRow(1001, "um mil um real")]
        //[DataRow(1002, "um mil dois reais")]
        //[DataRow(1010, "um mil dez reais")]
        //[DataRow(1017, "um mil dezessete reais")]
        //[DataRow(1020, "um mil vinte reais")]
        //[DataRow(1030, "um mil trinta reais")]
        //[DataRow(1021, "um mil vinte e um reais")]
        //[DataRow(1045, "um mil quarenta e cinco reais")]
        //[DataRow(1078, "um mil setenta e oito reais")]
        //[DataRow(1103, "um mil cento e três reais")]
        //[DataRow(1117, "um mil cento e dezessete reais")]
        //[DataRow(1171, "um mil cento e setenta e um reais")]
        //[DataRow(1193, "um mil cento e noventa e três reais")]
        //[DataRow(1130, "um mil cento e trinta reais")]
        //[DataRow(1170, "um mil cento e setenta reais")]
        //[DataRow(1110, "um mil cento e dez reais")]
        //[DataRow(1148, "um mil cento e quarenta e oito reais")]
        //[DataRow(1161, "um mil cento e sessenta e um reais")]
        //[DataRow(1200, "um mil duzentos reais")]
        //[DataRow(1300, "um mil trezentos reais")]
        //[DataRow(1710, "um mil setecentos e dez reais")]
        //[DataRow(1613, "um mil seiscentos e treze reais")]
        //[DataRow(1520, "um mil quinhentos e vinte reais")]
        //[DataRow(1437, "um mil quatrocentos e trinta e sete reais")]
        //[DataRow(2399, "dois mil trezentos e noventa e nove reais")]
        [DataRow(1110, "um mil cento e dez reais")]
        public void Deve_Converter_Unidades_De_Milhar_Centenas_Dezenas_E_Unidades_De_Real(double valorRecebido, string resultadoEsperado)
        {
            Humanizador hv = new Humanizador();

            string resultado = hv.HumanizarCheque(valorRecebido);

            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [DataRow(4764321600, 4)]
        [DataRow(4, 1)]
        [DataRow(40, 1)]
        [DataRow(768, 1)]
        [DataRow(4321, 2)]
        [DataRow(43213, 2)]
        [DataRow(432133, 2)]
        [DataRow(4321333, 3)]
        [DataRow(43213333, 3)]
        [DataRow(432133334, 3)]
        [DataRow(4321333344, 4)]
        [DataRow(43213333444, 4)]
        [DataRow(432133334444, 4)]
        [DataRow(4321333344443, 5)]
        [DataRow(43213333444433, 5)]
        [DataRow(432133334444333, 5)]
        [DataRow(4321333344443336, 6)]
        [DataRow(43213333444433366, 6)]
        [DataRow(432133334444333222, 6)]
        public void Deve_Separar_O_Valor_Em_Grupos(double valorRecebido, int tamanhoDaLista)
        {
            //Arrange
            Humanizador hv = new Humanizador();
            //Action
            long a = Convert.ToInt64(valorRecebido);
            var valorChequeString = Convert.ToString(a);
            List<string> resultado = hv.SepararEmGrupos(valorChequeString);

            //Assert
            Assert.AreEqual(tamanhoDaLista, resultado.Count);
        }

    }
}
