using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("user_lesson_attendance")]
public partial class UserLessonAttendance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("attendance_id")]
    public int AttendanceId { get; set; }

    [Column("lesson_id")]
    public int LessonId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("AttendanceId")]
    [InverseProperty("UserLessonAttendances")]
    [JsonIgnore]
    public virtual Attendance Attendance { get; set; } = null!;

    [ForeignKey("LessonId")]
    [InverseProperty("UserLessonAttendances")]
    [JsonIgnore]
    public virtual Lesson Lesson { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("UserLessonAttendances")]
    [JsonIgnore]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserLessonAttendances")]
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
