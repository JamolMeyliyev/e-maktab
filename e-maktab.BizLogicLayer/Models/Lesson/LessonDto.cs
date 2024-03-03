

namespace e_maktab.BizLogicLayer.Models;

public class LessonDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public int StateId { get; set; }
    public int ScienceId { get; set; }
    public int TeacherId { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly StartDate { get; set; }
}
