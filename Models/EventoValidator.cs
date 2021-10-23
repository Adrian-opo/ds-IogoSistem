using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IogoSistem.Models
{
    class EventoValidator : AbstractValidator<Evento>
    {
        public EventoValidator()
        {
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("O campo Tipo de evento não pode ficar em branco");
            RuleFor(x => x.Inicio).NotEmpty().WithMessage("O campo inicio do evento não pode ficar em branco");
            RuleFor(x => x.Fim).NotEmpty().WithMessage("O campo fim do evento não pode ficar em branco");
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("O campo observação não pode ficar em branco");


        }
    }
}
