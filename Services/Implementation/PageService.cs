using BugNoteManager.Interfaces;
using BugNoteManager.Services.Interface;

namespace BugNoteManager.Services.Implementation;

public class PageService : IPageService
{
    private readonly Stack<IPageBase> _history = new();
    public bool CanGoBack => _history.Skip(1).Any();

    public event Action<IPageBase>? OnPageChanged;

    public void Navigate(IPageBase page)
    {
        OnPageChanged?.Invoke(page);
        _history.Push(page);
    }

    public void GoBack()
    {
        if (!this.CanGoBack) return;

        _history.Pop();
        OnPageChanged?.Invoke(_history.Peek());
    }
}