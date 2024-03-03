using e_maktab.BizLogicLayer.Models.Role;
using System;


namespace e_maktab.BizLogicLayer.Models;

public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public int? OrganizationId { get; set; }
    public bool IsTeacher { get; set; }
    public int StateId { get; set; }
    public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
    public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
}
