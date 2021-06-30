using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IogoSistem_vs1
{
    class Util
    {
		public static bool IsEmail(string text)
		{
			bool blnValidEmail = false;
			Regex regEMail = new Regex(@"^[a-zA-Z][\w\.-]{1,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

			if (text.Length > 0)
				blnValidEmail = regEMail.IsMatch(text);


			return blnValidEmail;
		}


		public static bool IsCpf(string cpf)
		{
			
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();

			return cpf.EndsWith(digito);
		}

		public static bool IsCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

		public string Codigo { get; set; }
		public string Nome { get; set; }
		public string Sabor { get; set; }
		public string Categoria { get; set; }
		public string Peso_Litros { get; set; }
		public string Preco_Custo { get; set; }
		public string Preco_Venda { get; set; }
		public string Qtd_Estoque { get; set; }
		public string Descrição { get; set; }

		public object checkbox { get; set; }


		public string Horas { get; set; }

		public string Domingo { get; set; }
		public string Segunda { get; set; }
		public string Terca { get; set; }
		public string Quarta { get; set; }
		public string Quinta { get; set; }
		public string Sexta { get; set; }
		public string Sabado { get; set; }



		public string Semana1 { get; set; }
		public string Semana2 { get; set; }
		public string Semana3 { get; set; }
		public string Semana4 { get; set; }

	}
}
