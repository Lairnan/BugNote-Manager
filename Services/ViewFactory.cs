using System.Windows;
using BugNoteManager.Interfaces;

namespace BugNoteManager.Services;

public class ViewFactory : IViewFactory
{
    public IWindowBase? CreateView<TWindow, TPage>()
        where TWindow : IWindowBase
        where TPage : IPageBase
    {
        var window = IsWindowCreated<TWindow, TPage>();
        if (window != null) return window;
        window = IoC.Resolve<TWindow>();

        var vm = window.DataContext;
        if (vm == null) return null;

        vm.ChangePage<TPage>();
        return window;
    }

    private IWindowBase? IsWindowCreated<TWindow, TPage>()
        where TWindow : IWindowBase
        where TPage : IPageBase
    {
        var window = Application.Current.Windows.OfType<TWindow>().FirstOrDefault(s =>
            s.DataContext is { CurrentPage: TPage });
        return window;
    }
}