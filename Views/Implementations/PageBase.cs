using System.Windows.Controls;
using BugNoteManager.Interfaces;
using BugNoteManager.Interfaces.ViewModels.Pages;

namespace BugNoteManager.Views.Implementations;

public class PageBase : Page, IPageBase
{
    public PageBase()
    {
        this.Title = "Empty page";
    }

    public PageBase(IPageBaseVm pageBaseVm) : this()
    {
        this.DataContext = pageBaseVm;
    }

    public new IPageBaseVm? DataContext { get; }
}