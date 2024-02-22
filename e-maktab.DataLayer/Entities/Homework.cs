﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("homework")]
public partial class Homework
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("title")]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    [Column("full_text")]
    [StringLength(300)]
    public string FullText { get; set; } = null!;

    [Column("lesson_id")]
    public int LessonId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [ForeignKey("LessonId")]
    [InverseProperty("Homeworks")]
    public virtual Lesson Lesson { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("Homeworks")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("Homeworks")]
    public virtual Teacher Teacher { get; set; } = null!;
}
