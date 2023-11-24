using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Turismo_API.Models;

[Table("Person")]
public partial class Person
{
    [Key]
    [Column("personID")]
    public int PersonId { get; set; }

    [Column("name")]
    [StringLength(30)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("firstName")]
    [StringLength(50)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("lastName")]
    [StringLength(50)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("ci")]
    [StringLength(15)]
    [Unicode(false)]
    public string Ci { get; set; } = null!;

    [Column("phone")]
    public int Phone { get; set; }

    [Column("address")]
    [StringLength(100)]
    [Unicode(false)]
    public string Address { get; set; } = null!;

    [Column("birthDate", TypeName = "date")]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// M : Male
    /// F : Female
    /// </summary>
    [Column("gender")]
    [StringLength(1)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    /// <summary>
    /// 1: Enable
    /// 0: Disable
    /// </summary>
    [Column("state")]
    public byte State { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<PersonRegister>? PersonRegisters { get; set; } = new List<PersonRegister>();

    [InverseProperty("Person")]
    public virtual User? User { get; set; }

    public Person(int personId, string name, string firstName, string lastName, string ci, int phone, string address, DateTime birthDate, string gender, byte state)
    {
        PersonId = personId;
        Name = name;
        FirstName = firstName;
        LastName = lastName;
        Ci = ci;
        Phone = phone;
        Address = address;
        BirthDate = birthDate;
        Gender = gender;
        State = state;
    }
}
