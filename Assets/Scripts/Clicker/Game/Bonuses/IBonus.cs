namespace Clicker.Game.Bonuses
{
    public interface IBonus
    {
        float Duration { get; }
        void Apply(IBonusSubject bonusSubject);
        void Complete(IBonusSubject bonusSubject);
    }
}
