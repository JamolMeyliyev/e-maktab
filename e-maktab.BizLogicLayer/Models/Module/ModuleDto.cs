

namespace e_maktab.BizLogicLayer.Models;

public class ModuleDto
{
    public int Id { get; set; }
    public string ShortName { get; set; } = null!;
    public int StateId { get; set; }
    public string State { get; set; }

}
