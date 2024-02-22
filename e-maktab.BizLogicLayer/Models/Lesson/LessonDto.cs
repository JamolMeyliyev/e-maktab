using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Models;

public class LessonDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public int StateId { get; set; }
    public int ScienceId { get; set; }
    public int TeacherId { get; set; }
}
