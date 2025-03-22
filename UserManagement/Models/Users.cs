using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsUserAccountDeleted = false;

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

    }


    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
    }


}
