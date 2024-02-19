using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator() { }
}
