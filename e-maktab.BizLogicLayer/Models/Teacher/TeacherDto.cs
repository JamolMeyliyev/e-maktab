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

public class TeacherDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? OrganizationId { get; set; }
    public string Organization { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }

    //public List<HomeworkDto> Homeworks { get; set; } = new List<HomeworkDto>();
    //public List<ClassDto> Classes { get; set; } = new List<ClassDto>();
    //public List<LessonDto> Lessons { get; set; } = new List<LessonDto>();
}
