using Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User:Auditable
{ 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BirthOfDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}
