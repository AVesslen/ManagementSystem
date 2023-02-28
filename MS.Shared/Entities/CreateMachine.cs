using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Shared.Entities
{
    public class CreateMachine
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("n");

        [Required]
        [StringLength(50, ErrorMessage = "The name is too long.")]
        public string Name { get; set; } = string.Empty;
        public bool IsOnline { get; set; }    // online/offline status

        public DateTime LastUpdated { get; set; }
    }
}
