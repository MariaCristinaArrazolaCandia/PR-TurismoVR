using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Turismo_API.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("personID")]
    public int PersonId { get; set; }

    [Column("email")]
    [StringLength(80)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("userName")]
    [StringLength(20)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [Column("password")]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    /// <summary>
    /// S: SuperAdmin
    /// A: Admin
    /// C: Customer
    /// </summary>
    [Column("rol")]
    [StringLength(1)]
    [Unicode(false)]
    public string Rol { get; set; } = null!;

    [Column("codeRecovery")]
    [Unicode(false)]
    public string? CodeRecovery { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("User")]
    public virtual Person? Person { get; set; } = null!;

    [InverseProperty("UserPerson")]
    public virtual ICollection<PersonRegister>? PersonRegisters { get; set; } = new List<PersonRegister>();
}
