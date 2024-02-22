using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class CreateHomeworkDto
{ 
    public int StateId { get; set; }
    public string Title { get; set; } = null!;
    public string FullText { get; set; } = null!;
    public int LessonId { get; set; }
    public int TeacherId { get; set; }
}
