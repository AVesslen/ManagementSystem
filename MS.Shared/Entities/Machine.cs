using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Shared.Entities
{
    public class Machine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("n");
        public string Name { get; set; } = string.Empty;
        public bool IsOnline { get; set; }    // online/offline status

        public DateTime LastUpdated { get; set; }
    }
}
