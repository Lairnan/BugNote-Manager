using BugNoteManager.Interfaces.ViewModels.Pages;

namespace BugNoteManager.Interfaces.ViewModels.Windows;

public interface IWindowBaseVm : IViewModelBase
{
    string Title { get; set; }
    IPageBase? CurrentPage { get; }
    IPageBaseVm? CurrentPageVm { get; }
    IWindowBase WindowBase { get; set; }

    void ChangePage<T>() where T : IPageBase;
}