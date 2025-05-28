using MvvmBuilder.Notifies;

namespace BugNoteManager.Behaviors;

public class DialogButton : NotifyBase
{
    public DialogButton(ButtonType buttonType, string title, Action? action = null)
    {
        this.ButtonType = buttonType;
        this.Title = title;
        this.Action = action;
    }
    
    public ButtonType ButtonType { get; init; }
    public string Title { get; init; }
    public Action? Action { get; init; }
}