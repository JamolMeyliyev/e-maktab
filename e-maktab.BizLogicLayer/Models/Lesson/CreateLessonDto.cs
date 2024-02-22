using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class CreateLessonDto
{ 
    public int ClassId { get; set; }
    public int StateId { get; set; }
    public int ScienceId { get; set; }
    public int TeacherId { get; set; }
}
