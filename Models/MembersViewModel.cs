using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MineCraft_Bedrock_Server_Manager.Models
{
    public class MembersViewModel : PageModel
    {
        public List<IdentityUser> Users { get; set; }
    }
}