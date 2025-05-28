using BugNoteManager.Services.Interface;

namespace BugNoteManager.Interfaces.ViewModels.Pages;

public interface IPageBaseVm : IViewModelBase
{
    void SetBaseWindow(IWindowBase windowBase);
    void SetPageService(IPageService pageService);
}