using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hama.Core.Models;

[System.ComponentModel.DataAnnotations.Schema.Table("DocumentPatterns")]
[RepoDb.Attributes.Map("DocumentPatterns")]
public partial class DocumentPattern
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsActive { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("DocumentPatterns")]
    public virtual DocumentPatternCategory Category { get; set; } = null!;

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("DocumentPatterns")]
    public virtual User CreatedByUser { get; set; } = null!;
}
