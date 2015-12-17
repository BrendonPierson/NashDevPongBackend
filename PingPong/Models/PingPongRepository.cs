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

        public List<Player> GetAllPlayersRanked()
        {
            var query = from users in _context.Players select users;
            return query.OrderBy(u => -1 * (u.EloRating)).ToList();
        }


        public List<DoublesTeam> GetAllDoublesTeams()
        {
            var query = from team in _context.DoublesTeams select team;
            return query.ToList();
        }

        public List<SinglesMatch> GetAllSinglesMatches()
        {
            var query = from match in _context.SinglesMatches select match;
            List<SinglesMatch> sMatches = query.ToList();
            sMatches.Sort();
            return sMatches;
        }

        public List<DoublesMatch> GetAllDoublesMatches()
        {
            var query = from match in _context.DoublesMatches select match;
            List<DoublesMatch> dMatch = query.ToList();
            dMatch.Sort();
            return dMatch;
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

        public bool IsHandleAvailable(string handle)
        {
            bool available = false;
            try
            {
                Player some_user = GetPlayerByHandle(handle);
                if (some_user == null)
                {
                    available = true;
                }
            }
            catch (InvalidOperationException) { }

            return available;
        }

        public List<Player> SearchByHandle(string handle)
        {
            var query = from user in _context.Players select user;
            List<Player> found_users = query.Where(user => user.Handle.Contains(handle)).ToList();
            found_users.Sort();
            return found_users;
        }

        public bool AddSinglesMatch(Player pOne, Player pTwo, int sOne, int sTwo)
        {
            SinglesMatch match = new SinglesMatch();
            match.MatchDate = DateTime.Now;
            match.PlayerOneElo = pOne.EloRating;
            match.PlayerTwoElo = pTwo.EloRating;
            match.PlayerOneScore = sOne;
            match.PlayerTwoScore = sTwo;
            // It would be unnecessary to save the elo ratings separate from the players if the current state of the player
            // was permanently stored.  I don't think this is the case, only a reference to that player is stored
            bool isAdded = true;
            try
            {
                _context.SinglesMatches.Add(match);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddDoublesMatch(DoublesTeam tOne, DoublesTeam tTwo, int sOne, int sTwo)
        {
            DoublesMatch match = new DoublesMatch();
            match.MatchDate = DateTime.Now;
            match.TeamOneElo = tOne.EloRating;
            match.TeamTwoElo = tTwo.EloRating;
            match.TeamOneScore = sOne;
            match.TeamTwoScore = sTwo;
            // It would be unnecessary to save the elo ratings separate from the players if the current state of the player
            // was permanently stored.  I don't think this is the case, only a reference to that player is stored
            bool isAdded = true;
            try
            {
                _context.DoublesMatches.Add(match);
                _context.SaveChanges();
            }
            catch (Exception)

            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddSinglesTournament(string tourneyName)
        {
            SinglesTournament tourney = new SinglesTournament();
            tourney.TournamentName = tourneyName;
            tourney.StartDate = DateTime.Now;
            tourney.IsActive = true;
            tourney.TournamentId = _context.SinglesTournaments.Count();
            tourney.SinglesMatches = new List<SinglesMatch>();
            tourney.Players = new List<Player>();
            bool isAdded = true;
            try
            {
                _context.SinglesTournaments.Add(tourney);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public SinglesTournament GetSinglesTournamentById(int tourneyId)
        {
            var query = from t in _context.SinglesTournaments where t.TournamentId == tourneyId select t;
            return query.SingleOrDefault();
        }

        public bool AddSinglesMatchToTourney(int tourneyId, SinglesMatch match)
        {
            bool isAdded = true;
            try
            {
                SinglesTournament tourney = GetSinglesTournamentById(tourneyId);
                tourney.SinglesMatches.Add(match); 
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool ArchiveSinglesTournament(int tourneyId)
        {
            bool isUpdated = true;
            try
            {
                SinglesTournament tourney = GetSinglesTournamentById(tourneyId);
                tourney.IsActive = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public DoublesTournament GetDoublesTournamentById(int tourneyId)
        {
            var query = from t in _context.DoublesTournaments where t.TournamentId == tourneyId select t;
            return query.SingleOrDefault();
        }

        public bool ArchiveDoublesTournament(int tourneyId)
        {
            bool isUpdated = true;
            try
            {
                DoublesTournament tourney = GetDoublesTournamentById(tourneyId);
                tourney.IsActive = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool AddDoublesTournament(string tourneyName)
        {
            DoublesTournament tourney = new DoublesTournament();
            tourney.TournamentName = tourneyName;
            tourney.StartDate = DateTime.Now;
            tourney.IsActive = true;
            tourney.TournamentId = _context.DoublesTournaments.Count();
            tourney.DoublesMatches = new List<DoublesMatch>();
            tourney.Teams = new List<DoublesTeam>();
            bool isAdded = true;
            try
            {
                _context.DoublesTournaments.Add(tourney);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddDoublesMatchToTourney(int tourneyId, DoublesMatch match)
        {
            bool isAdded = true;
            try
            {
                DoublesTournament tourney = GetDoublesTournamentById(tourneyId);

                tourney.DoublesMatches.Add(match);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddPlayerToTournament(int tourneyId, Player player)
        {
            bool isAdded = true;
            try
            {
                SinglesTournament tourney = GetSinglesTournamentById(tourneyId);

                tourney.Players.Add(player);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddTeamToTournament(int tourneyId, DoublesTeam team)
        {
            bool isAdded = true;
            try
            {
                DoublesTournament tourney = GetDoublesTournamentById(tourneyId);

                tourney.Teams.Add(team);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddNewPlayer(string handle, string firstName, string lastName)
        {
            bool isAdded = true;

            Player player = new Player();
            player.Handle = handle;
            player.FirstName = firstName;
            player.LastName = lastName;
            player.SingesMatches = new List<SinglesMatch>();
            player.Teams = new List<DoublesTeam>();
            player.EloRating = 1300;

            try
            {
                _context.Players.Add(player);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }

        public bool AddNewTeam(Player playerOne, Player playerTwo, string teamName)
        {
            bool isAdded = true;

            DoublesTeam t = new DoublesTeam();
            t.EloRating = 1300;
            t.Matches = new List<DoublesMatch>();
            t.TeamMembers = new Player[] { playerOne, playerTwo };
            t.TeamName = teamName;
            t.Tournaments = new List<DoublesTournament>();

            try
            {
                _context.DoublesTeams.Add(t);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
            }
            return isAdded;
        }
    }
}