using MvvmBuilder.Notifies;
using BugNoteManager.Interfaces;
using BugNoteManager.Interfaces.ViewModels.Pages;
using BugNoteManager.Interfaces.ViewModels.Windows;
using BugNoteManager.Services.Interface;

namespace BugNoteManager.ViewModels;

public class AdditionalViewModel : NotifyBase, IAdditionalWindowVm
{
    private readonly IPageService _pageService;

    public AdditionalViewModel(IPageService pageService)
    {
        _pageService = pageService;
        _pageService.OnPageChanged += NavigateAction;
    }

    private async void NavigateAction(IPageBase page)
    {
        this.Title = page.Title;
        this.CurrentPageVm = page.DataContext;
        if (page.DataContext != null)
        {
            page.DataContext.SetPageService(_pageService);
            page.DataContext.SetBaseWindow(this.WindowBase!);
        }

        await Task.Delay(350);
        this.CurrentPage = page;
        await Task.Delay(25);
    }

    public IPageBase CurrentPage
    {
        get => GetProperty<IPageBase>();
        private set => SetProperty(value);
    }

    public string Title
    {
        get => GetProperty<string>();
        set => SetProperty(value, startValue: "Доп. окно");
    }

    public IPageBaseVm? CurrentPageVm
    {
        get => GetProperty<IPageBaseVm?>();
        private set => SetProperty(value);
    }

    public IWindowBase WindowBase
    {
        get => GetProperty<IWindowBase>();
        set => SetProperty(value);
    }

    public void ChangePage<T>()
        where T : IPageBase
    {
        var page = IoC.Resolve<T>();
        _pageService.Navigate(page);
    }
}