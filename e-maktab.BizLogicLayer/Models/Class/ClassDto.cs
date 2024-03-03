using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace e_maktab.BizLogicLayer.Models;

public class ClassDto
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public string Teacher { get; set; }
    public int StateId { get; set; }
    public string State { get; set; }
    public  string ShortName { get; set; }
    public  string FullName { get; set; }
    public  List<LessonDto> Lessons { get; set; } 
    public virtual List<UserDto> Users { get; set; } = new List<UserDto>();
}
