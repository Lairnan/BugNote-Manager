# 🐞 BugNote Manager

[Русский](./README.ru.md)

Minimalistic WPF application for managing bug and task notes. MVVM-based architecture, local storage via LiteDB.

---

## ⚙️ Features

- Add and edit **bug** and **task** notes
- Structured bug fields:
  - Analyst contact
  - Tester contact
  - Business process explanation
  - Config/test data
  - Code analysis, hypothesis, comments
- Statuses:
  - `Proposed`, `Active`, `In PR Review`, `Ready for QA`, `Resolved`
- Checklist for bug investigation steps
- Lightweight UI with `MainWindow` and `AdditionalWindow`
- All notes stored locally in `notes.db` (LiteDB)

---

## 🗂️ Project Structure

```
/Models
  - Note.cs (abstract)
  - BugNote.cs
  - TaskNote.cs
  - Status.cs (enum)
/ViewModels
  - MainViewModel.cs
  - EditNoteViewModel.cs
  - NotificationViewModel.cs
/Views
  /Windows
    - MainWindow.xaml
    - AdditionalWindow.xaml
  /Pages
    - ViewTask.xaml
    - EditTask.xaml
    - AddTask.xaml
    - Notification.xaml
/Services
  - INoteStorageService.cs
  - LiteDbNoteStorageService.cs
/Data
  - notes.db
```

---

## 🚀 Getting Started

1. Clone this repository:
   ```bash
   git clone https://github.com/lairnan/BugNote-Manager.git
   ```
2. Open in Visual Studio
3. Install dependencies:
   ```bash
   dotnet add package LiteDB
   ```
4. Run `MainWindow.xaml`

---

## 📄 Example

```csharp
public class BugNote : Note
{
    public string AnalystContact { get; set; }
    public string TesterContact { get; set; }
    public bool IsBusinessProcessReviewed { get; set; }
    public bool IsConfigReviewed { get; set; }
    public bool IsCodeAnalyzed { get; set; }
    public string BusinessProcessNotes { get; set; }
    public string ConfigNotes { get; set; }
    public string CodeAnalysisNotes { get; set; }
    public string Hypothesis { get; set; }
    public string Comments { get; set; }
}
```

---

## 📃 License

MIT — free to use and modify.
