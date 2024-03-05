using e_maktab.BizLogicLayer.Models.Role;
using System;


namespace e_maktab.BizLogicLayer.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public int OrganizationId { get; set; }
    public string Organization { get; set; }
    public bool IsTeacher { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
}
