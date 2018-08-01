namespace LifeSim.Core.Engine.Menu
{
    public interface IMenuLauncher
    {
        void DisplayContent(string path);
        void LoadDisplays(string path);
        void UserSelector();
    }
}