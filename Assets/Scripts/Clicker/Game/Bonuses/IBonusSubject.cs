namespace Clicker.Game.Bonuses
{
    public interface IBonusSubject
    {
        void SetOriginalSize();
        void IncreaseSize(int increaseFactor);
        void SetPointsMultiplier(int scoreMultiplier);
        void ClearPointsMultiplier();
        void SetFrizzing();
        void CancelFrizzing();
    }
}