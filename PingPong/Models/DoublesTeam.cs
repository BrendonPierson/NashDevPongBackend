using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class DoublesTeam
    {
        [Key]
        public int TeamId { get; set; }
        
        [Required]
        public Player[] TeamMembers { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public string TeamName { get; set; }

        [Required]
        public int EloRating { get; set; }

        public virtual List<DoublesMatch> Matches { get; set; }
        public virtual List<DoublesTournament> Tournaments { get; set; }

    }
}