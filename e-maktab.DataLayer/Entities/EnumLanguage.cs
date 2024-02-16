﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.AutoGenerated;

[Table("enum_language")]
public partial class EnumLanguage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; } = null!;

    [Column("short_name")]
    [StringLength(50)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [InverseProperty("Language")]
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    [InverseProperty("Language")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
