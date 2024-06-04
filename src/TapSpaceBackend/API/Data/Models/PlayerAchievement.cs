using API.Data.Models;

namespace API.Models;

public class PlayerAchievement
{
    public long PlayerId { get; set; }
    public int AchievementId { get; set; }
    public int Progress { get; set; }

    public Player? Player { get; set; }
    public Achievement? Achievement { get; set; }
}