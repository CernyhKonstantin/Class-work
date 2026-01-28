using System;
using UI.Interfaces;
using UI.DarkTheme;

class Program
{
    static void Main()
    {
        IUIFactory factory = new DarkUIFactory();

        IButton button = factory.CreateButton();
        ITextBox textBox = factory.CreateTextBox();

        button.Render();
        textBox.Render();
    }
}
