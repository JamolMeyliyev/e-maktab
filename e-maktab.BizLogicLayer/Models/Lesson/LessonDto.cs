

using e_maktab.DataLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_maktab.BizLogicLayer.Models;

public class LessonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ClassId { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public int ScienceId { get; set; }
    public string Science { get; set; }
    public int TeacherId { get; set; }
    public string Teacher { get; set; }
    public DateOnly Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public List<HomeworkDto> Homeworks { get; set; } = new List<HomeworkDto>();
    

}
