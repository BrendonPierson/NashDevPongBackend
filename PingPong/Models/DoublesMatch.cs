using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class DoublesMatch
    {
        [Key]
        public int MatchId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public DoublesTeam TeamOne { get; set; }

        [Required]
        public DoublesTeam TeamTwo { get; set; }

        [Required]
        [Range(0, 100)]
        public int TeamOneScore { get; set; }

        [Required]
        [Range(0, 100)]
        public int TeamTwoScore { get; set; }

        [Required]
        public int TeamOneElo { get; set; }

        [Required]
        public int TeamTwoElo { get; set; }
    }
}