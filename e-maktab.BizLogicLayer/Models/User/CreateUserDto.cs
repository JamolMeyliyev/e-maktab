﻿

namespace e_maktab.BizLogicLayer.Models;

public class CreateUserDto
{
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public int OrganizationId { get; set; }
    public bool IsTeacher { get; set; }
    public int StateId { get; set; }
    public int? ClassId { get; set; }
    public List<int> Roles { get; set; }
}
