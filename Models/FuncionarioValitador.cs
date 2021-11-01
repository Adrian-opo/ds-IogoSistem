using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace IogoSistem.Models
{
	class FuncionarioValitador : AbstractValidator<Funcionario>
	{
		public FuncionarioValitador()
		{
			RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo Nome é obrigatorio, favor preencher!");
			RuleFor(x => x.CPF).NotEqual("___.___.___-__").WithMessage("O campo cpf não pode ficar em branco");
			RuleFor(x => x.CPF.Replace("_", "")).Must(IsCpf).WithMessage("CPF inválido");
			RuleFor(x => x.Email).NotEmpty().WithMessage("O campo email não pode ficar em branco!");
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Telefone).NotEmpty().WithMessage("O campo Telefone é obrigatorio, favor preencher!");
			RuleFor(x => x.DataAdimissao).NotEmpty().WithMessage("O campo Data de Admissão é obrigatorio, favor preencher!");
			RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("O Data de Nascimento Nome é obrigatorio, favor preencher!");
			RuleFor(x => x.RG).NotEmpty().WithMessage("O RG é obrigatorio, favor preencher!");
			RuleFor(x => x.CargaHoraria).NotEmpty().WithMessage("O CargaHoraria é obrigatorio, favor preencher!");
			RuleFor(x => x.NumeroCarteira).NotEmpty().WithMessage("O NumeroCarteira é obrigatorio, favor preencher!");
			RuleFor(x => x.Salario).NotEmpty().WithMessage("O Salario é obrigatorio, favor preencher!");
			RuleFor(x => x.SetorTrabalho).NotEmpty().WithMessage("O SetorTrabalho é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.Numero).NotEmpty().WithMessage("O numero é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.Lagradouro).NotEmpty().WithMessage("O Logradouro é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.CEP).NotEmpty().WithMessage("O CEP é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.Cidade).NotEmpty().WithMessage("O Cidade é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.UF).NotEmpty().WithMessage("O UF é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.Pais).NotEmpty().WithMessage("O Pais é obrigatorio, favor preencher!");
			RuleFor(x => x.Endereco.Bairro).NotEmpty().WithMessage("O Bairro é obrigatorio, favor preencher!");








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


	}
}
