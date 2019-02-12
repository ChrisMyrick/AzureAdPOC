using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthPOC.Model
{
    public class PermissionAttrib
    {
        public PermissionAttrib()
        {
            this.PermissionGroups = new HashSet<PermissionGroup>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public string Description { get; set; }

        // If AssignableInAD is true, this level should be created in AD as a AD Security Group
        // and the admin then can assign people into that group.
        public bool AssignableInAD { get; set; }

        public virtual ICollection<PermissionGroup> PermissionGroups { get; set; }

    }
}