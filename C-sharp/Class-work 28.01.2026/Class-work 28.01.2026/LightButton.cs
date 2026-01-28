using UI.Interfaces;

namespace UI.LightTheme
{
    class LightButton : IButton
    {
        public void Render() => Console.WriteLine("Render light button");
    }
}
