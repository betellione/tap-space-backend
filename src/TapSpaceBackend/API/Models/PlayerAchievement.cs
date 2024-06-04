namespace API.Models;

public class PlayerAchievement
{
    public int PlayerId { get; set; }
    public int AchievementId { get; set; }
    public int Progress { get; set; }

    public Player? Player { get; set; }
    public Achievement? Achievement { get; set; }
}