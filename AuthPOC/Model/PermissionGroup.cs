using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthPOC.Model
{
    /// <summary>
    /// PermissionGroup serves as template of a collection of permissionLevels. If a PermissionGroup has been assigned to a user, the user then
    /// has all the permissionLevel defined in the PermissionGroup
    /// 
    /// </summary>
    public class PermissionGroup
    {
        public PermissionGroup()
        {
            this.PermissionAttribs = new HashSet<PermissionAttrib>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PermissionAttrib> PermissionAttribs { get; set; }

    }
}