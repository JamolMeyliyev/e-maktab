using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace e_maktab.DataLayer.Entities;

[Table("modules")]
public partial class Module
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("short_name")]
    [StringLength(250)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(300)]
    public string FullName { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [InverseProperty("Module")]
    public virtual ICollection<RoleModule> RoleModules { get; set; } = new List<RoleModule>();

    [ForeignKey("StateId")]
    [InverseProperty("Modules")]
    public virtual EnumState State { get; set; } = null!;
}

