using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Resources
{
    public class UserCreateResource
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserCreateResourceValidator: AbstractValidator<UserCreateResource>
    {
        public UserCreateResourceValidator()
        {
            RuleFor(u => u.Fullname)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MaximumLength(50).WithMessage("Ad Soyad maximum 50 xarakter ola bilər")
                .MinimumLength(3).WithMessage("Ad Soyad maximum 50 xarakter ola bilər");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .EmailAddress().WithMessage("E-poçt ünvanı düzgün olsun")
                .MaximumLength(50).WithMessage("E-poçt ünvanı maximum 50 xarakter ola bilər");

            RuleFor(u=>u.Password)
                .NotEmpty().WithMessage("Boş ola bilməz")
                .MinimumLength(6).WithMessage("Şifrə düzgün olsun")
                .MaximumLength(50).WithMessage("Şifrə maximum 50 xarakter ola bilər");
        }
    }
}
