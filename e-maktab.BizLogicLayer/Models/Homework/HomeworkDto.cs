using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class HomeworkDto
{
    public int Id { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public string Title { get; set; } = null!;
    public string FullText { get; set; } = null!;
    public int LessonId { get; set; }
    public string Lesson { get; set; }
    public int TeacherId { get; set; }
    public string Teacher { get; set; }
}
