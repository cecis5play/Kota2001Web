using Microsoft.AspNetCore.Identity;

namespace Kota2001Web.Data.Entities
{
    public class User : IdentityUser
    { 
    public string? FirstName { get; set; }
     public string? LastName { get; set;}

    }
}
