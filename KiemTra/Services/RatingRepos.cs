using KiemTra.Models;
using Microsoft.EntityFrameworkCore;

namespace KiemTra.Services
{
    public class RatingRepos : IRating
    {
        private readonly AppDbContext _context;

        public RatingRepos(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rating>> GetRatingByMonthAsync(int month, int year, int page)
        {
            const int pageSize = 10;

            var allScores = await (from s in _context.Scores
                                   join u in _context.Users on s.UserID equals u.UserID
                                   where s.Timestamp.Month == month && s.Timestamp.Year == year
                                   group s by new { s.UserID, u.UserName, u.Avatar } into g
                                   select new
                                   {
                                       UserId = g.Key.UserID,
                                       Fullname = g.Key.UserName,
                                       Avatar = g.Key.Avatar,
                                       TotalScore = g.Sum(x => x.Value)
                                   })
                                   .OrderByDescending(x => x.TotalScore)
                                   .ToListAsync();

            var rankedScores = allScores
                .Select((score, index) => new Rating
                {
                    Rank = index + 1,
                    UserId = score.UserId,
                    Fullname = score.Fullname,
                    Avatar = score.Avatar,
                    TotalScore = score.TotalScore
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return rankedScores;
        }

    }
}
