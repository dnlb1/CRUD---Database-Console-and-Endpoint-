using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHPYQ8_HFT_2021222.Models
{
    public class Game_publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GP_Id { get; set; }
        public int release_year { get; set; }

        public int GameId { get; set; }
        public int PublisherId { get; set; }

        public virtual Game Game { get; private set; }
        public virtual Publisher Publisher { get; private set; }

        public Game_publisher()
        {

        }

        public Game_publisher(string line)
        {
            string[] split = line.Split('#');
            GP_Id = int.Parse(split[0]);
            GameId = int.Parse(split[1]);
            PublisherId = int.Parse(split[2]);
            release_year = int.Parse(split[3]);
        }
    }
}
