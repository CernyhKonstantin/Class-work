using System;

#region Interfaces

interface IButton
{
    void Render();
}

interface ITextBox
{
    void Render();
}

interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}

#endregion

#region Concrete UI Elements - Light Theme

class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Render light button");
    }
}

class LightTextBox : ITextBox
{
    public void Render()
    {
        Console.WriteLine("Render light textbox");
    }
}

#endregion

#region Concrete UI Elements - Dark Theme

class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Render dark button");
    }
}

class DarkTextBox : ITextBox
{
    public void Render()
    {
        Console.WriteLine("Render dark textbox");
    }
}

#endregion

#region Concrete Factories

class LightUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ITextBox CreateTextBox()
    {
        return new LightTextBox();
    }
}

class DarkUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ITextBox CreateTextBox()
    {
        return new DarkTextBox();
    }
}

#endregion

#region Program (Client)

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

#endregion
