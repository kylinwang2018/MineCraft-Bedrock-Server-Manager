using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MineCraft_Bedrock_Server_Manager.Models
{
    public class MembersViewModel : PageModel
    {
        public ICollection<UserWithRole> UserWithRoles { get; set; }
    }

    public class UserWithRole
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}