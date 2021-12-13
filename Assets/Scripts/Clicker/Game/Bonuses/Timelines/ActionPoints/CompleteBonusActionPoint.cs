namespace Clicker.Game.Bonuses.Timelines.ActionPoints
{
    public class CompleteBonusActionPoint : IActionPoint
    {
        private readonly IBonus _bonus;
        private readonly IBonusSubject _bonusSubject;

        public CompleteBonusActionPoint(IBonus bonus, IBonusSubject bonusSubject)
        {
            _bonus = bonus;
            _bonusSubject = bonusSubject;
        }

        public void Execute()
        {
            _bonus.Complete(_bonusSubject);
        }
    }
}