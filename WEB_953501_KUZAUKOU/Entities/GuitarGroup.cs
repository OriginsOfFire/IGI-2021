using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953501_KUZAUKOU.Entities
{
    public class GuitarGroup
    {
        public int GuitarGroupId { get; set; }
        public string GroupName { get; set; }
        public List<Guitar> Guitars { get; set; }
    }
}
