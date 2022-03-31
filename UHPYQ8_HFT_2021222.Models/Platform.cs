using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHPYQ8_HFT_2021222.Models
{
    public class Platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public Platform()
        {
            Games = new HashSet<Game>();
        }

        public Platform(string line)
        {
            string[] split = line.Split('#');
            PlatformId = int.Parse(split[0]);
            PlatformName = split[1];
            Games = new HashSet<Game>();
        }
    }
}
