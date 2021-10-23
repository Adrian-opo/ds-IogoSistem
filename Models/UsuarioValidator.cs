using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace IogoSistem.Models
{
    class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo nome não pode ficar em branco");
            RuleFor(x => x.CPF).NotEqual("___.___.___-__").WithMessage("O campo cpf não pode ficar em branco");

			
			RuleFor(x => x.CPF.Replace("_","")).Must(IsCpf).WithMessage("CPF inválido");
			
            RuleFor(x => x.Email).NotEmpty().WithMessage("O campo email não pode ficar em branco");
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Senha).NotEmpty().WithMessage("O campo senha não pode ficar em branco");
			
		
		}

		private static bool IsCpf(string cpf)
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

		static bool IsEmail(string email)
        {
			
			Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

			if (rg.IsMatch(email))
            {
				return true;

            }


			return false;
		}
	}
}
