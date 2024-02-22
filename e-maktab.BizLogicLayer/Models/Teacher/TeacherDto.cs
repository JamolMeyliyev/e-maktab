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
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? OrganizationId { get; set; }
    public int StateId { get; set; }
    public int ClassId { get; set; }
    public DateTime DateOfCreated { get; set; }
    public DateTime? DateOfModified { get; set; }
    public virtual ICollection<Homework> Homeworks { get; set; } 
    public virtual ICollection<Lesson> Lessons { get; set; } 

 
 
}
