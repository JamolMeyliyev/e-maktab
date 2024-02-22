using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("class")]
public partial class Class
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("short_name")]
    [StringLength(50)]
    public string? ShortName { get; set; }

    [Column("full_name")]
    [StringLength(50)]
    public string? FullName { get; set; }

    [Column("date_of_created", TypeName = "timestamp without time zone")]
    public DateTime DateOfCreated { get; set; }

    [Column("date_of_modified", TypeName = "timestamp without time zone")]
    public DateTime? DateOfModified { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [ForeignKey("StateId")]
    [InverseProperty("Classes")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("Class")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    [InverseProperty("Class")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
