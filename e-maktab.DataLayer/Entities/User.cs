﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("users")]
public partial class User
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

    [Column("password_hash")]
    [StringLength(250)]
    public string PasswordHash { get; set; } = null!;

    [Column("email")]
    [StringLength(250)]
    public string? Email { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    public string? PhoneNumber { get; set; }

    [Column("organization_id")]
    public int? OrganizationId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("date_of_created", TypeName = "timestamp without time zone")]
    public DateTime DateOfCreated { get; set; }

    [Column("date_of_modified", TypeName = "timestamp without time zone")]
    public DateTime? DateOfModified { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Users")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("OrganizationId")]
    [InverseProperty("Users")]
    public virtual Organization? Organization { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("Users")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<UserLessonAttendance> UserLessonAttendances { get; set; } = new List<UserLessonAttendance>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
