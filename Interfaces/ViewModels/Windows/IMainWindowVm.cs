using System.Windows.Input;

namespace BugNoteManager.Interfaces.ViewModels.Windows;

public interface IMainWindowVm : IWindowBaseVm
{
    ICommand ShowSettingsCommand { get; }
    ICommand GoToBackCommand { get; }
}