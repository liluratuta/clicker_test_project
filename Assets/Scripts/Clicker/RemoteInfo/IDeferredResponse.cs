namespace Clicker.RemoteInfo
{
    public interface IDeferredResponse
    {
        void Execute(ILevelsInfo levelsInfo);
    }
}
