using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanizadorDeCheques.Dominio
{
    public class Humanizador
    {
        private Dictionary<int, string> valores = new Dictionary<int, string>()
        {   {1, "um"},           {2, "dois"},         {3, "três"},
            {4, "quatro"},       {5, "cinco"},        {6, "seis"},         {7, "sete"},
            {8, "oito"},         {9, "nove"},         {10, "dez"},         {11, "onze"},
            {12, "doze"},        {13, "treze"},       {14, "quatorze"},    {15, "quinze"},
            {16, "dezesseis"},   {17, "dezessete"},   {18, "dezoito"},     {19, "dezenove"},
            {20, "vinte"},       {30, "trinta"},      {40, "quarenta"},    {50, "cinquenta"},
            {60, "sessenta"},    {70, "setenta"},     {80, "oitenta"},     {90, "noventa"},
            {100, "cem"},        {200, "duzentos"},   {300, "trezentos"},  {400, "quatrocentos"},
            {500, "quinhentos"}, {600, "seiscentos"}, {700, "setecentos"}, {800, "oitocentos"},
            {900, "novecentos"} };

        private Dictionary<int, string> unidades = new Dictionary<int, string>()
        {
            {0, "" },    {1, "um"},   {2, "dois"}, {3, "três"}, {4, "quatro"}, {5, "cinco"},
            {6, "seis"}, {7, "sete"}, {8, "oito"}, {9, "nove"} };

        private Dictionary<int, string> dezenas = new Dictionary<int, string>()
        {
            {0, ""},           {10, "dez"},      {11, "onze"},     {12, "doze"},
            {13, "treze"},     {14, "quatorze"}, {15, "quinze"},   {16, "dezesseis"},
            {17, "dezessete"}, {18, "dezoito"},  {19, "dezenove"}, {2, "vinte"},
            {3, "trinta"},     {4, "quarenta"},  {5, "cinquenta"}, {6, "sessenta"},
            {7, "setenta"},    {8, "oitenta"},   {9, "noventa"} };

        private Dictionary<int, string> centenas = new Dictionary<int, string>()
        {
            {0, ""},{1, "cem"}, {2, "duzentos"},   {3, "trezentos"},  {4, "quatrocentos"},
            {5, "quinhentos"},  {6, "seiscentos"}, {7, "setecentos"}, {8, "oitocentos"},
            {9, "novecentos"} };

        public string HumanizarCheque(double valorCheque)
        {
            string resultado = "", centavos = "";

            long parteInteira = Convert.ToInt64(Math.Floor(valorCheque));

            if (valorCheque != parteInteira)
                centavos = ObterOsCentavos(valorCheque, parteInteira);

            var valorChequeString = Convert.ToString(parteInteira);

            List<string> valorAgrupado = SepararEmGrupos(valorChequeString);

            List<List<string>> listasDeValoresPorExtenso
                = CriarListaDeValoresPorExtenso(valorAgrupado);

            int contSuperior = listasDeValoresPorExtenso.Count;

            for (int i = 0; i < listasDeValoresPorExtenso.Count; i++)
            {
                var list = listasDeValoresPorExtenso[i];

                string textoAtual = "";

                int contInferior = list.Count;

                for (int j = 0; j < list.Count; j++)
                {
                    textoAtual += list[j];

                    if (contInferior > 1)
                    {
                        textoAtual += " e ";
                        contInferior--;
                    }
                }
                if (i == 0)
                    resultado += " mil";

                if (resultado.Length > 0)
                    resultado += " " + textoAtual;
                else
                    resultado += textoAtual;
            }

            if (resultado == "um")
                resultado += " real";
            else
                resultado += " reais";

            return resultado;
        }

        private string DefinirSufixo(int quantidadeDeGrupos, string valorLista)
        {
            string sufixo = "";

            if (quantidadeDeGrupos == 2)
                sufixo = "mil";
            else if (quantidadeDeGrupos == 3)
                sufixo = "milhões";
            else if (quantidadeDeGrupos == 4)
                sufixo = "bilhões";
            else
                sufixo = "";
            return sufixo;
        }

        private string ObterOsCentavos(double valorCheque, long parteInteira)
        {
            string centavos;
            var depoisVirgula = Math.Truncate((valorCheque - parteInteira) * 100);
            centavos = Convert.ToString(depoisVirgula);
            return centavos;
        }

        private List<List<string>> CriarListaDeValoresPorExtenso(List<string> valorAgrupado)
        {
            List<string> valoresPorExtenso;
            List<List<string>> listasDeValoresPorExtenso = new List<List<string>>();
            valorAgrupado.Reverse();

            foreach (var item in valorAgrupado)
            {
                valoresPorExtenso = new List<string>();

                var valor = item;

                while (valor.Length > 0)
                {
                    valoresPorExtenso.Add(RetornaValorPorExtenso(valor));

                    if (valor.Length == 2 && valor.StartsWith("1"))
                        valor = valor.Remove(0, 2);
                    else
                        valor = valor.Remove(0, 1);
                }
                valoresPorExtenso.RemoveAll(x => x == "");

                listasDeValoresPorExtenso.Add(valoresPorExtenso);
            }

            return listasDeValoresPorExtenso;
        }

        public List<string> SepararEmGrupos(string valor)
        {
            List<string> valoresAgrupados = new List<string>();

            while (valor.Length > 0)
            {
                if (valor.Length >= 3)
                {
                    int inicioSequencia = valor.Length - 3;

                    string sequencia = valor.Substring(inicioSequencia, 3);

                    valor = valor.Remove(inicioSequencia);

                    valoresAgrupados.Add(sequencia);
                }
                else
                {
                    valoresAgrupados.Add(valor);

                    valor = valor.Remove(0);
                }
            }

            return valoresAgrupados;
        }

        private string AdicionarUnidadePorExtenso(string numero)
        {
            var chave = Convert.ToInt32(numero);

            return unidades[chave];
        }

        private string AdicionarDezenaPorExtenso(string numero)
        {
            int chave;

            string value, resultado = "";

            if (VerificaValorRedondo(numero) && numero.StartsWith("1") == false)
            {
                value = numero.Substring(0, 1);

                chave = Convert.ToInt32(value);

                return dezenas[chave];
            }
            else
            {
                if (numero.StartsWith("1"))
                {
                    value = numero.Substring(0, 2);

                    chave = Convert.ToInt32(value);

                    return dezenas[chave];
                }
                else
                {
                    value = numero.Substring(0, 1);

                    chave = Convert.ToInt32(value);

                    resultado += dezenas[chave];
                }
            }
            return resultado;
        }

        private string AdicionarCentenaPorExtenso(string numero)
        {
            int chave;

            string value, resultado = "";

            if (VerificaValorRedondo(numero))
            {
                value = numero.Substring(0, 1);

                chave = Convert.ToInt32(value);

                return centenas[chave];
            }
            else
            {
                if (numero.StartsWith("1"))
                    return "cento";
                else
                {
                    value = numero.Substring(0, 1);

                    chave = Convert.ToInt32(value);

                    resultado += centenas[chave];
                }
            }
            return resultado;
        }

        private string RetornaValorPorExtenso(string numero)
        {
            string resultado = "";

            if (numero.Length == 3)
                resultado = AdicionarCentenaPorExtenso(numero);

            if (numero.Length == 2)
                resultado = AdicionarDezenaPorExtenso(numero);

            if (numero.Length == 1)
                resultado = AdicionarUnidadePorExtenso(numero);

            return resultado;
        }

        private bool VerificaValorRedondo(string valor)
        {
            string valorSemPrimeiroDigito = valor.Remove(0, 1);

            string zeros = "";

            for (int i = 0; i < valorSemPrimeiroDigito.Length; i++)
                zeros += "0";

            if (valorSemPrimeiroDigito == zeros)
                return true;

            return false;
        }
    }
}
