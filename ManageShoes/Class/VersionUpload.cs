using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageShoes.Class
{
    [Serializable]
    public class VersionUpload
    {
        public double time { get; set; }
        public String pcName { get; set; }

        public VersionUpload(double time, String pcName)
        {
            this.time = time;
            this.pcName = pcName;
        }
    }
}
