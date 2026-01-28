using UI.Interfaces;

namespace UI.DarkTheme
{
    class DarkTextBox : ITextBox
    {
        public void Render() => Console.WriteLine("Render dark textbox");
    }
}
