using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("enum_state")]
public partial class EnumState
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

    [InverseProperty("State")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("State")]
    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    [InverseProperty("State")]
    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    [InverseProperty("State")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("State")]
    public virtual ICollection<SysRole> SysRoles { get; set; } = new List<SysRole>();

    [InverseProperty("State")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    [InverseProperty("State")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
