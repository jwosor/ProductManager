using FluentValidation;
using ProductManager.WebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.WebApi
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        { 
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Error campo requerido")
                .NotNull().WithMessage("Error valor del campo no puede ser Null");

             RuleFor(p => p.MakingDate)
                .LessThan(p => p.ValidityDate).WithMessage("La fecha de fabricación no puede ser mayor o igual a la fecha de vencimiento.");

            RuleFor(p => p.IdSupplier)
               .NotEmpty().WithMessage("Error campo requerido")
               .NotNull().WithMessage("Error valor del campo no puede ser Null");
        }

    }
}
