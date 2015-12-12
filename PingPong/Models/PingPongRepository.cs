using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PingPong.Models
{
    public class PingPongRepository
    {
        private PingPongContext _context;
        public PingPongContext Context { get { return _context; } }

        public  PingPongRepository()
        {
            _context = new PingPongContext();
        }

        public PingPongRepository(PingPongContext a_context)
        {
            _context = a_context;
        }

        public List<Player> GetAllUsers()
        {
            var query = from users in _context.Players select users;
            return query.ToList();
        }

        public List<DoublesTeam> GetAllDoublesTeams()
        {
            var query = from team in _context.DoublesTeams select team;
            return query.ToList();
        }

        public List<SinglesMatch> GetAllSinglesMatches()
        {
            var query = from match in _context.SinglesMatches select match;
            return query.ToList();
        }

        public List<DoublesMatch> GetAllDoublesMatches()
        {
            var query = from match in _context.DoublesMatches select match;
            return query.ToList();
        }

        public List<SinglesTournament> GetAllSinglesTournaments()
        {
            var query = from tourney in _context.SinglesTournaments select tourney;
            return query.ToList();
        }

        public List<DoublesTournament> GetAllDoublesTournaments()
        {
            var query = from tourney in _context.DoublesTournaments select tourney;
            return query.ToList();
        }

        public Player GetPlayerByHandle(string handle)
        {
            var query = from user in _context.Players where user.Handle.ToLower() == handle.ToLower() select user;
            return query.SingleOrDefault();
        }


    }
}