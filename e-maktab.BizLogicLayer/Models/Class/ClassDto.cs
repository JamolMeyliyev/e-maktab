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

public class ClassDto
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
    public DateTime DateOfCreated { get; set; }
    public DateTime? DateOfModified { get; set; }
    public int StateId { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
