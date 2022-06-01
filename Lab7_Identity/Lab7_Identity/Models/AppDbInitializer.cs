using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Lab7_Identity.Models
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roleAdministrator = new IdentityRole { Name = "Administrator" };
            var roleEmployer      = new IdentityRole { Name = "Employer" };
            var roleGuest         = new IdentityRole { Name = "Guest" };

            var adminUser = new ApplicationUser { Email = "admin@belstu.by", UserName = "admin@belstu.by" };
            var employerUser = new ApplicationUser { Email = "employer@belstu.by", UserName = "employer@belstu.by" };
            var guestUser = new ApplicationUser { Email = "guest@belstu.by", UserName = "guest@belstu.by" };
            var superUser = new ApplicationUser { Email = "super@belstu.by", UserName = "super@belstu.by" };

            bool administratorRoleCreated = roleManager.Create(roleAdministrator).Succeeded;
            bool employerRoleCreated = roleManager.Create(roleEmployer).Succeeded;
            bool guestRoleCreated = roleManager.Create(roleGuest).Succeeded;

            bool adminUserCreated = userManager.Create(adminUser, "admin").Succeeded;
            bool employerUserCreated = userManager.Create(employerUser, "employer").Succeeded;
            bool guestUserCreated = userManager.Create(guestUser, "guest").Succeeded;
            bool superUserCreated = userManager.Create(superUser, "super").Succeeded;

            if(administratorRoleCreated && adminUserCreated)
            {
                Debug.WriteLine("++ admin created");
                userManager.AddToRole(adminUser.Id, roleAdministrator.Name);
            }
            if(employerRoleCreated && employerUserCreated)
            {
                Debug.WriteLine("++ employerUser created");
                userManager.AddToRole(employerUser.Id, roleEmployer.Name);
            }
            if(guestRoleCreated && guestUserCreated)
            {
                Debug.WriteLine("++ guestUser created");
                userManager.AddToRole(guestUser.Id, roleGuest.Name);
            }
            if(guestRoleCreated && employerRoleCreated && administratorRoleCreated && superUserCreated)
            {
                Debug.WriteLine("++ superUser created");
                userManager.AddToRole(superUser.Id, roleGuest.Name);
                userManager.AddToRole(superUser.Id, roleEmployer.Name);
                userManager.AddToRole(superUser.Id, roleAdministrator.Name);
            }

            base.Seed(context);
        }
    }
}