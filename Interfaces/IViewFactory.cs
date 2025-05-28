namespace BugNoteManager.Interfaces;

public interface IViewFactory
{
    IWindowBase? CreateView<TWindow, TPage>()
        where TWindow : IWindowBase
        where TPage : IPageBase;
}