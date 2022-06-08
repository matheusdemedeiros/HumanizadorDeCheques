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
        //[DataRow(100, "cem reais")]
        //[DataRow(9318901.81, "novecentos e trinta e um reais")]
        [DataRow(1000000, "um milhão reais")]
        //[DataRow(600, "seiscentos")]
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
