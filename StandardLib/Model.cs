using System.ComponentModel.DataAnnotations;
using JsonApiDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace App1.Models
{
    public class Person : Identifiable
    {
        [Attr("name")]
        public string Name { get; set; }
    }

    public class Login
    {
        // Constructor
        public Login() { } // When I place a breakpoint here, the debugger returns a NULL model in 3.1 but returns the model with the correct values from PostMan.

        // Properties
        [Required]
        [EmailAddress]
        [Attr("username")]
        public string UserName { get; set; }

        [Required]
        [Attr("password")]
        public string Password { get; set; }

        [Required]
        [Attr("rememberme")]
        public bool RememberMe { get; set; }
    }

}