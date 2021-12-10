namespace Clicker.Game.Bonuses
{
    public interface IBonusApplicator
    {
        void IncreaseSize(float increaseFactor);
        void SetOriginalSize();
        void SetPointsMultiplier(int scoreMultiplier);
        void ClearPointsMultiplier();
        void SetFrizzing();
        void CancelFrizzing();
    }
}
