﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHPYQ8_HFT_2021222.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [Required]
        [StringLength(240)]
        public string PublisherName { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public Publisher()
        {
            Games = new HashSet<Game>();
        }

        public Publisher(string line)
        {
            string[] split = line.Split('#');
            PublisherId = int.Parse(split[0]);
            PublisherName = split[1];
            Games = new HashSet<Game>();
        }
    }
}