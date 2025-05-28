using BugNoteManager.Interfaces;

namespace BugNoteManager.Behaviors;

public static class Factory
{
    public static async Task<DialogButton> ShowPopUp(string title, string message, double timeout, bool newWindow = true,
        params DialogButton[]? buttons)
    {
        if (buttons == null || buttons.Length == 0)
            buttons = new DialogButton[]
            {
                new(ButtonType.Ok, "Okay"),
            };
        
        IWindowBase? window = null;
        if (!newWindow)
            window = Global.LastActiveWindow;

        window ??= IoC.Resolve<IWindowBase>();

        var dialog = IoC.Resolve<IPopUp>();
        dialog.SetWindowBase(window);
        dialog.SetButtons(buttons);
        dialog.SetMessage(message);
        dialog.SetTitle(title);
        dialog.SetTimeout(timeout);
        dialog.ShowPopUp();

        var button = dialog.GetSelectedButton();
        button.Action?.Invoke();

        return button;
    }

    public static async Task<DialogButton> ShowPopUp(string title, string message, bool newWindow = true,
        params DialogButton[]? buttons)
    {
        return await ShowPopUp(title, message, 0, newWindow, buttons);
    }
}