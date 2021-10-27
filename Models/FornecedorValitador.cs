using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace IogoSistem.Models
{
    class FornecedorValitador: AbstractValidator<Fornecedor>
    {

        public FornecedorValitador()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo Nome é obrigatorio, favor preencher!");
            RuleFor(x => x.Celular).NotEmpty().WithMessage("O campo Celular é obrigatorio, favor preencher!");
            RuleFor(x => x.ProdutoFornecido).NotEmpty().WithMessage("O campo Produto Fornecido é obrigatorio, favor preencher!");
        }

    }
}
