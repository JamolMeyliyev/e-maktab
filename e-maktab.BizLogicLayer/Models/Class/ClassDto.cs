using e_maktab.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace e_maktab.BizLogicLayer.Models;

public class ClassDto
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public string? ShortName { get; set; }
    public string? FullName { get; set; }
    public DateTime DateOfCreated { get; set; }
    public DateTime? DateOfModified { get; set; }
    public int StateId { get; set; }
    
}
