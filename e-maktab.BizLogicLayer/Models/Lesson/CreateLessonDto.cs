﻿

using System.ComponentModel.DataAnnotations.Schema;

namespace e_maktab.BizLogicLayer.Models;

public class CreateLessonDto
{
    public required string Name { get; set; }
    public int ClassId { get; set; }
    public int StateId { get; set; }
    public int ScienceId { get; set; }
    public int TeacherId { get; set; }
    public DateOnly LessonDay { get; set; }
    public TimeOnly StartTime { get; set; }
    //public DateTime Date { get; set; }

}
