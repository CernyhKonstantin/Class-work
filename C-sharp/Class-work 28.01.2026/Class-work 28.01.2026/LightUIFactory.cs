using UI.Interfaces;

namespace UI.LightTheme
{
    class LightUIFactory : IUIFactory
    {
        public IButton CreateButton() => new LightButton();
        public ITextBox CreateTextBox() => new LightTextBox();
    }
}
