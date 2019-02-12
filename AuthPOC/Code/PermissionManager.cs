using AuthPOC.DAL;
using AuthPOC.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MoreLinq;
using System;

namespace AuthPOC.Code
{
    public class PermissionManager
    {
        public List<PermissionGroup> AppPermissionGroups { get;  }
        public List<PermissionAttrib> AssignableAttribs { get; }
        public List<PermissionAttrib> UnAssignableAttribs { get; }
        public List<ADAssignable> ADAssignables { get; set; }



        public PermissionManager(PermissionDbContext db)
        {
            AppPermissionGroups = db.PermissionGroups.Include(pg => pg.PermissionAttribs).ToList();
            AssignableAttribs = db.PermissionAttribs.Where(attrib => attrib.AssignableInAD).ToList();
            UnAssignableAttribs = db.PermissionAttribs.Where(attrib => !attrib.AssignableInAD).ToList();
            var groupAssignable = db.PermissionGroups.Select(g => new ADAssignable { Name = g.Name, IsPermissionGroup = true }).ToList();
            var attributeAssignable = db.PermissionAttribs.Where(attrib => attrib.AssignableInAD).Select(a => new ADAssignable { Name = a.Name, IsPermissionGroup = false });
            ADAssignables = groupAssignable.Concat(attributeAssignable).ToList();
        }

        internal List<PermissionAttrib> getPermissionAttributions(List<ADAssignable> adAssignables)
        {
            return adAssignables.Where(assignable => !assignable.IsPermissionGroup)
                .Select(assignable => AssignableAttribs.Where(attr => attr.Name == assignable.Name).First())
                .ToList();
        }

        internal List<PermissionGroup> getPermissionGroups(List<ADAssignable> adAssignables)
        {
            return adAssignables.Where(assignable => assignable.IsPermissionGroup)
                .Select(assignable => AppPermissionGroups.Where(ap => ap.Name == assignable.Name).First())
                .ToList();
        }

        public List<PermissionAttrib> GetEffectivePermissionAttrib(List<ADAssignable> adAssignables)
        {
            var attribsInGroups = adAssignables.Where(a => a.IsPermissionGroup)
                .Select(assignedGroups => AppPermissionGroups.Where(appGroup => appGroup.Name == assignedGroups.Name).First())
                .SelectMany(group => group.PermissionAttribs)
                .DistinctBy(attrb => attrb.Name);

            var assignedAttribs = adAssignables.Where(a => !a.IsPermissionGroup)
                .Select(assignedAttrib => AssignableAttribs.Where(assignable => assignable.Name == assignedAttrib.Name).First());

            var effectiveAttribs = attribsInGroups.Union(assignedAttribs).DistinctBy(attrib => attrib.Name);

            return effectiveAttribs.ToList();
            
        }
    }
}
