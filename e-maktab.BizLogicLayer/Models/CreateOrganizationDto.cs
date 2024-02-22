namespace e_maktab.BizLogicLayer.Models;

public class CreateOrganizationDto
{
    public string ShortName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string? Inn { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int StateId { get; set; }
}
