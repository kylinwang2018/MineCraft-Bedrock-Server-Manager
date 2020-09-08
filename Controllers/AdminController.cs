using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MineCraft_Bedrock_Server_Manager.Models;
using Microsoft.AspNetCore.Authorization;
using MineCraft_Bedrock_Server_Manager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MineCraft_Bedrock_Server_Manager.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Members()
        {
            return View(GetUserWithRoles());
        }

        private MembersViewModel GetUserWithRoles()
        {
            MembersViewModel model = new MembersViewModel();
            using (SqliteCommand cmd = new SqliteCommand())
            {
                cmd.CommandText = @"
SELECT [a].[Id] AS [Id], [a].[Email], [a1].[Name] AS [Role]
FROM [AspNetUsers] AS [a]
INNER JOIN [AspNetUserRoles] AS [a0] ON [a].[Id] = [a0].[UserId]
INNER JOIN [AspNetRoles] AS [a1] ON [a0].[RoleId] = [a1].[Id]";
                model.UserWithRoles = SQLiteHelper.GetDataTableFromSQLAsync<UserWithRole>(cmd, "DefaultConnection").Result;
            }

            return model;
        }

        [HttpDelete]
        public IActionResult DeleteUser(string UserId)
        {

            return Json(new { status = true, data= GetUserWithRoles().UserWithRoles.ToList() });
        }
    }
}