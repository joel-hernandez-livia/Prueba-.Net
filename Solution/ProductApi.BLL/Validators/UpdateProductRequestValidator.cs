using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProductApi.BLL.DTOs;

namespace ProductApi.BLL.Validators
{
    public class UpdateProductRequestValidator
        : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            //RuleFor(x => x.ProductId)
            //    .GreaterThan(0)
            //    .WithMessage("El ProductId debe ser mayor a 0.");


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100)
                .WithMessage("El nombre no puede superar los 100 caracteres.");


            RuleFor(x => x.Status)
                .InclusiveBetween(0, 1)
                .WithMessage("El Status debe ser 0 o 1.");


            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El stock no puede ser negativo.");


            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("La descripción no puede superar los 500 caracteres.");


            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("El precio debe ser mayor a 0.");
        }
    }
}