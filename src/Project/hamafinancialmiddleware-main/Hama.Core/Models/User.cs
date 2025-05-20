using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hama.Core.Models;

[System.ComponentModel.DataAnnotations.Schema.Table("Users")]
[RepoDb.Attributes.Map("Users")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(256)]
    public string PasswordHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<DocumentPattern> DocumentPatterns { get; set; } = new List<DocumentPattern>();

    [InverseProperty("User")]
    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
