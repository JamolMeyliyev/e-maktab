using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_maktab.DataLayer.Entities;

[Table("homework")]
public partial class Homework
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("lesson_id")]
    public int LessonId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("title")]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    [Column("full_text")]
    [StringLength(300)]
    public string FullText { get; set; } = null!;

    [ForeignKey("LessonId")]
    [InverseProperty("Homeworks")]
    [JsonIgnore]
    public virtual Lesson Lesson { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("Homeworks")]
    [JsonIgnore]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("Homeworks")]
    [JsonIgnore]
    public virtual Teacher Teacher { get; set; } = null!;
}
