using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UHPYQ8_HFT_2021222.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [StringLength(240)]
        public string Title { get; set; }

        [Range(0, 10000)]
        public double Price { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public int PlatformId { get; set; }
        public virtual Platform Platform { get; set; }

        public Game()
        {

        }

        public Game(string line)
        {
            string[] split = line.Split('#');
            GameId = int.Parse(split[0]);
            Title = split[1];
            Price = double.Parse(split[2]);
            PublisherId = int.Parse(split[3]);
            Rating = double.Parse(split[4]);
            PlatformId = int.Parse(split[5]);
        }

    }
}
