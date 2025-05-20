using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hama.Core.Models;

[System.ComponentModel.DataAnnotations.Schema.Table("DocumentPatternCategories")]
[RepoDb.Attributes.Map("DocumentPatternCategories")]
public partial class DocumentPatternCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<DocumentPattern> DocumentPatterns { get; set; } = new List<DocumentPattern>();
}
