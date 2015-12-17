using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class SinglesTournament
    {
        [Key]
        public int TournamentId { get; set; }

        public string TournamentName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        
        public virtual List<Player> Players { get; set; }

        
        public virtual List<SinglesMatch> SinglesMatches { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}