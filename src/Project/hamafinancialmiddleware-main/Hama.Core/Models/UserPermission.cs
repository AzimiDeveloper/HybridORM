using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hama.Core.Models;

[Index("PermissionId", "UserId", Name = "IX_UserPermissions", IsUnique = true)]
[System.ComponentModel.DataAnnotations.Schema.Table("UserPermissions")]
[RepoDb.Attributes.Map("UserPermissions")]
public partial class UserPermission
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PermissionId { get; set; }

    [ForeignKey("PermissionId")]
    [InverseProperty("UserPermissions")]
    public virtual Permission Permission { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserPermissions")]
    public virtual User User { get; set; } = null!;
}
