namespace BugNoteManager.Interfaces;

public interface IViewBase<T>
    where T : IViewModelBase
{
    string Title { get; set; }
    T? DataContext { get; }
}