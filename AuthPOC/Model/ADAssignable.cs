using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthPOC.Model
{
    public class ADAssignable
    {
        public bool IsPermissionGroup { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return IsPermissionGroup ? "g_" + Name : "a_" + Name;
        }
    }
}
