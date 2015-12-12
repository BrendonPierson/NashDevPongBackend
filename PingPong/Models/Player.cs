using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class Player :IComparable
    {
        [Key]
        public int PlayerId { get; set; }

        [MaxLength(64)]
        public string FirstName { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public string Handle { get; set; }

        [Required]
        public int EloRating { get; set; }

        public List<SinglesMatch> SingesMatches { get; set; }
        public List<SinglesMatch> DoublesMatches { get; set; }

        public List<DoublesTeam> Teams { get; set; }

        public int CompareTo(object obj)
        {
            Player other = obj as Player;
            if(other != null)
            {
                return this.Handle.CompareTo(other.Handle);
            } else
            {
                throw new ArgumentException("Object is not a Player");
            }
        }
    }
}