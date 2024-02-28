using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("role_module")]
public partial class RoleModule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("module_id")]
    public int ModuleId { get; set; }

    [ForeignKey("ModuleId")]
    [InverseProperty("RoleModules")]
    public virtual Module Module { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("RoleModules")]
    public virtual Role Role { get; set; } = null!;
}
