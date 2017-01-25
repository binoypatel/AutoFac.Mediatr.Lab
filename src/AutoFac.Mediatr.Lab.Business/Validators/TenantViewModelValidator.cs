using AutoFac.Mediatr.Core.ViewModel;
using FluentValidation;

namespace AutoFac.Mediatr.Lab.Business.Validators
{
    public sealed class TenantViewModelValidator : AbstractValidator<TenantViewModel>
    {
        public TenantViewModelValidator()
        {
            RuleFor(vm => vm.UnitName)
                .NotEmpty();

            RuleFor(vm => vm.Password)
                .NotEmpty()
                .Length(6, 25);
        }
    }
}