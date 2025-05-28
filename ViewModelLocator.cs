using BugNoteManager.Interfaces.ViewModels.Pages;
using BugNoteManager.Interfaces.ViewModels.Windows;

namespace BugNoteManager;

public class ViewModelLocator
{
    // Windows
    public IMainWindowVm MainViewModel => IoC.Resolve<IMainWindowVm>();
    public IAdditionalWindowVm AdditionalViewModel => IoC.Resolve<IAdditionalWindowVm>();
    
    // Pages
}