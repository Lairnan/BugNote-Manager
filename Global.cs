using BugNoteManager.Interfaces;

namespace BugNoteManager;

public static class Global
{
    public static IWindowBase LastActiveWindow { get; set; } = null!;
}