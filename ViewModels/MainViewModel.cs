using System.Windows;
using System.Windows.Input;
using BugNoteManager.Interfaces;
using BugNoteManager.Interfaces.ViewModels.Pages;
using BugNoteManager.Interfaces.ViewModels.Windows;
using BugNoteManager.Services.Interface;
using BugNoteManager.Views.Implementations;
using MvvmBuilder.Commands;
using MvvmBuilder.Notifies;

namespace BugNoteManager.ViewModels;

public class MainViewModel : NotifyBase, IMainWindowVm
{
    private readonly IPageService _pageService;

    private IPageBaseVm? _currentPageVm;
    private ICommand? _goToBackCommand;

    private ICommand? _showSettingsCommand;

    public MainViewModel(IPageService pageService)
    {
        _pageService = pageService;
        _pageService.OnPageChanged += NavigateAction;

		NavigationCommands.BrowseBack.InputGestures.Clear();
        NavigationCommands.BrowseForward.InputGestures.Clear();
        NavigationCommands.BrowseHome.InputGestures.Clear();
        NavigationCommands.BrowseStop.InputGestures.Clear();
    }

    public IPageBase CurrentPage
    {
        get => GetProperty<IPageBase>(() => new PageBase());
        private set => SetProperty(value);
    }

    public string Title
    {
        get => GetProperty<string>();
        set => SetProperty(value, startValue: "Главное окно");
    }

    public ICommand ShowSettingsCommand => _showSettingsCommand ??= new RelayCommand(() =>
    {
        MessageBox.Show("Work In Progress");
    });

    public ICommand GoToBackCommand => _goToBackCommand ??=
        new RelayCommand(() => _pageService.GoBack(), () => _pageService.CanGoBack);

    private async void NavigateAction(IPageBase page)
    {
        this.Title = page.Title;
        this.CurrentPageVm = page.DataContext;

        if (page.DataContext != null)
        {
            page.DataContext.SetPageService(_pageService);
            page.DataContext.SetBaseWindow(this.WindowBase);
        }
        
        await Task.Delay(350);
        this.CurrentPage = page;
        await Task.Delay(25);
    }
    
    public IPageBaseVm? CurrentPageVm
    {
        get => _currentPageVm;
        private set => SetProperty(ref _currentPageVm, value);
    }

    public IWindowBase WindowBase
    {
        get => GetProperty<IWindowBase>();
        set => SetProperty(value, action: s => { this.CurrentPageVm?.SetBaseWindow(s); });
    }

    public void ChangePage<T>()
        where T : IPageBase
    {
        var page = IoC.Resolve<T>();
        _pageService.Navigate(page);
    }
}