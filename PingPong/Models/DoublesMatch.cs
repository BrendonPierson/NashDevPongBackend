using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class DoublesMatch : IComparable
    {
        [Key]
        public int MatchId { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public virtual DoublesTeam TeamOne { get; set; }

        [Required]
        public virtual DoublesTeam TeamTwo { get; set; }

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

        public int CompareTo(object obj)
        {
            DoublesMatch other = obj as DoublesMatch;
            return -1 * (this.MatchDate.CompareTo(other.MatchDate));
        }
    }
}