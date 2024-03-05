using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace e_maktab.DataLayer.Entities;

[Table("user_role")]
public partial class UserRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    [JsonIgnore]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("UserRoles")]
    [JsonIgnore]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRoles")]
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
