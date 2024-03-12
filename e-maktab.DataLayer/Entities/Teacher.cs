using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;


[Table("teacher")]
public partial class Teacher
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(250)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(300)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(250)]
    public string? Email { get; set; }

   

    [Column("phone_number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("date_of_created", TypeName = "timestamp without time zone")]
    public DateTime DateOfCreated { get; set; }

    [Column("date_of_modified", TypeName = "timestamp without time zone")]
    public DateTime? DateOfModified { get; set; }

    [InverseProperty("Teacher")]
    [JsonIgnore]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("Teacher")]
    [JsonIgnore]
    public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    [InverseProperty("Teacher")]
    [JsonIgnore]
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [ForeignKey("OrganizationId")]
    [InverseProperty("Teachers")]
    [JsonIgnore]
    public virtual Organization? Organization { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("Teachers")]
    [JsonIgnore]
    public virtual EnumState State { get; set; } = null!;
}
