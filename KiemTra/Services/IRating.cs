using KiemTra.Models;

namespace KiemTra.Services
{
    public interface IRating
    {
        Task<List<Rating>> GetRatingByMonthAsync(int month, int year,int page);
           
    }
}
