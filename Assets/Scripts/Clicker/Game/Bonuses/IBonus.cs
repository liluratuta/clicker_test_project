namespace Clicker.Game.Bonuses
{
    public interface IBonus
    {
        void Apply(IBonusApplicator applicator);
    }
}
