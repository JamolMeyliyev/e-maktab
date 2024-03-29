﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_maktab.DataLayer.Entities;

[Table("lesson")]
public partial class Lesson
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("science_id")]
    public int ScienceId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("lesson_day")]
    public DateOnly LessonDay { get; set; }

    [Column("start_time")]
    public TimeOnly StartTime { get; set; }

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
