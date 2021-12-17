using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953501_KUZAUKOU.Entities
{
    public class Guitar
    {
        public int GuitarId { get; set; }
        public string GuitarName { get; set; }
        public string Description { get; set; }
        public int Strings { get; set; }
        public string Image { get; set; }

        public int GuitarGroupId { get; set; }
        public GuitarGroup Group { get; set; }
    }
}
