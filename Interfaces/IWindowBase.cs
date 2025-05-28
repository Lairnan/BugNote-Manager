using System.Windows.Input;
using BugNoteManager.Interfaces.ViewModels.Windows;

namespace BugNoteManager.Interfaces;

public interface IWindowBase : IViewBase<IWindowBaseVm>
{
    void Show();
    void Close();
    bool? ShowDialog();
    bool? DialogResult { get; set; }
    
    void ShowPopUp(IPopUp popUp);
    void ClosePopUp();
    void DragMovePopUp(object sender, MouseButtonEventArgs e);
}