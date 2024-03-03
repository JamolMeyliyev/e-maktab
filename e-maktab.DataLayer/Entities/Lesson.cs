﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_maktab.DataLayer.Entities;

[Table("lesson")]
public partial class Lesson
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime? CreatedDate { get; set; }

    [Column("end_date", TypeName = "timestamp without time zone")]
    public DateTime? EndDate { get; set; }

    [Column("science_id")]
    public int ScienceId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }


    public DateOnly Day { get; set; }
    public TimeOnly StartDate { get; set; }




    [ForeignKey("ClassId")]
    [InverseProperty("Lessons")]
    public virtual Class Class { get; set; } = null!;

    [InverseProperty("Lesson")]
    public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    [ForeignKey("ScienceId")]
    [InverseProperty("Lessons")]
    public virtual Science Science { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("Lessons")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("Lessons")]
    public virtual Teacher Teacher { get; set; } = null!;

    [InverseProperty("Lesson")]
    public virtual ICollection<UserLessonAttendance> UserLessonAttendances { get; set; } = new List<UserLessonAttendance>();
}
