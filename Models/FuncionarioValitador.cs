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
            RuleFor(x => x.CPF).NotEqual("   .   .   -").WithMessage("O campo CPF é obrigatorio, favor preencher!");
        }
    }
}
