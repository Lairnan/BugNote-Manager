using BugNoteManager.Interfaces;

namespace BugNoteManager.Services.Interface;

public interface IPageService
{
    bool CanGoBack { get; }
    event Action<IPageBase> OnPageChanged;

    void Navigate(IPageBase page);
    void GoBack();
}