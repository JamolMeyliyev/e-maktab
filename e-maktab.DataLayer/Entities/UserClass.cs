﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_maktab.DataLayer.Entities;

[Table("user_class")]
public partial class UserClass
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("class_id")]
    public int ClassId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("UserClasses")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserClasses")]
    public virtual User User { get; set; } = null!;
}
