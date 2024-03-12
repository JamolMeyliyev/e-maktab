using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class CreateTeacherDto
{

    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? OrganizationId { get; set; }
    public int StateId { get; set; }
}
