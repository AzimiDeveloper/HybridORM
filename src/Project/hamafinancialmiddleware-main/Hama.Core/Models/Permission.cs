using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hama.Core.Models;

[Index("ParentId", Name = "IX_Permissions_ParentId")]
[Index("Name", Name = "UQ__Permissi__737584F68FF46ACB", IsUnique = true)]
[System.ComponentModel.DataAnnotations.Schema.Table("Permissions")]
[RepoDb.Attributes.Map("Permissions")]
public partial class Permission
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string? Description { get; set; }

    public int? ParentId { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<Permission> InverseParent { get; set; } = new List<Permission>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual Permission? Parent { get; set; }

    [InverseProperty("Permission")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    [InverseProperty("Permission")]
    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
