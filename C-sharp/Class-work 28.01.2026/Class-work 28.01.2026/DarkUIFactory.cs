using UI.Interfaces;

namespace UI.DarkTheme
{
    class DarkUIFactory : IUIFactory
    {
        public IButton CreateButton() => new DarkButton();
        public ITextBox CreateTextBox() => new DarkTextBox();
    }
}
