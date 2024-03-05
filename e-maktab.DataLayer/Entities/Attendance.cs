using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("attendance")]
public partial class Attendance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [InverseProperty("Attendance")]
    [JsonIgnore]
    public virtual ICollection<UserLessonAttendance> UserLessonAttendances { get; set; } = new List<UserLessonAttendance>();
}
