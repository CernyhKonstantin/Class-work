using UI.Interfaces;

namespace UI.DarkTheme
{
    class DarkButton : IButton
    {
        public void Render() => Console.WriteLine("Render dark button");
    }
}
