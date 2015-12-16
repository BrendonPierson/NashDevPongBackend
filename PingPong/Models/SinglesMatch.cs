using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PingPong.Models
{
    public class SinglesMatch : IComparable
    {
        [Key]
        public int MatchId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public virtual Player PlayerOne { get; set; }

        [Required]
        public virtual Player PlayerTwo { get; set; }

        [Required]
        [Range(0,100)]
        public int PlayerOneScore { get; set; }

        [Required]
        [Range(0,100)]
        public int PlayerTwoScore { get; set; }

        [Required]
        public int PlayerOneElo { get; set; }

        [Required]
        public int PlayerTwoElo { get; set; }

        public int CompareTo(object obj)
        {
            SinglesMatch other = obj as SinglesMatch;
            return -1 * (this.MatchDate.CompareTo(other.MatchDate));
        }
    }
}