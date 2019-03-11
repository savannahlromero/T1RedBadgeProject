using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using RedBadgeBackend.Data;

[assembly: OwinStartup(typeof(RedBadgeBackend.Startup))]

namespace RedBadgeBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        // method for creating default roles and Admin user   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // creating Admin Role & default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // create Admin role   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Admin user                  

                var user = new ApplicationUser();
                //user.UserName = "Admin"; <---- IF WE NEED THIS WE HAVE IT
                user.Email = "admin@admin.com";

                string userPWD = "Admin123!";

                var chkUser = UserManager.Create(user, userPWD);

                // make aforementioned user an Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Venue Owner role    
            if (!roleManager.RoleExists("VenueOwner"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "VenueOwner";
                roleManager.Create(role);

            }

            // creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }
    }
}
