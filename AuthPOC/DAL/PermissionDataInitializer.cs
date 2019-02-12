using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AuthPOC.Model;

namespace AuthPOC.DAL
{
    public class PermissionDataInitializer : DropCreateDatabaseAlways<PermissionDbContext>
    {
        protected override void Seed(PermissionDbContext context)
        {


            string seedDataCommand = "INSERT INTO [dbo].[PermissionGroups] ([Id], [Name],[Description])" +
                " VALUES " +
                   " (1, 'Family', 'This PermissionGroup has typical family accesss')," +
                   " (2, 'Visitor', 'This PermissionGroup has typical visitor accesss')," +
                   " (3, 'Friend', 'This PermissionGroup has typical friend accesss')," +
                   " (4, 'Yard Helper', 'This PermissionGroup has typical yard helper accesss') ";
            context.Database.ExecuteSqlCommand(seedDataCommand);

            seedDataCommand = "INSERT INTO [dbo].[PermissionAttribs] ([Id], [Name],[Description],[AssignableInAD])" +
                " VALUES " +
               " (1, 'Living Room ALL', 'Access to all living room fetures', 0)," +
               " (2, 'Recreation Room ALL', 'Access to all recreation room features', 0)," +
               " (3, 'Yard ALL', 'Access to all Yard features', 0)," +
               " (4, 'Yard Enter', 'Can open the backyard gate', 0)," +
               " (5, 'Yard Play', 'Can play in the yard', 1), " +
               " (6, 'Yard Use Lawn Mower ', 'Can use lawn mower', 1)";
            context.Database.ExecuteSqlCommand(seedDataCommand);

            // Family can do anything
            seedDataCommand = "INSERT INTO [dbo].[PermissionGroupPermissionAttribs] ([PermissionGroup_Id], [PermissionAttrib_Id])" +
                " VALUES " +
                " (1, 1), (1, 2), (1, 3)";
            context.Database.ExecuteSqlCommand(seedDataCommand);

            // Visitor can user Living Room and Enter Yard
            seedDataCommand = "INSERT INTO [dbo].[PermissionGroupPermissionAttribs] ([PermissionGroup_Id], [PermissionAttrib_Id])" +
                " VALUES " +
                " (2, 1), (2, 4)";
            context.Database.ExecuteSqlCommand(seedDataCommand);


            // Friends can user Recreation Room
            seedDataCommand = "INSERT INTO [dbo].[PermissionGroupPermissionAttribs] ([PermissionGroup_Id], [PermissionAttrib_Id])" +
                " VALUES " +
                " (3, 2)";
            context.Database.ExecuteSqlCommand(seedDataCommand);

            // Yard Helper do everything in yard
            seedDataCommand = "INSERT INTO [dbo].[PermissionGroupPermissionAttribs] ([PermissionGroup_Id], [PermissionAttrib_Id])" +
                " VALUES " +
                " (4,3)";
            context.Database.ExecuteSqlCommand(seedDataCommand);


            base.Seed(context);
        }
    }
}
