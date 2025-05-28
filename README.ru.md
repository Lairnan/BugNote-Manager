# 🐞 BugNote Manager

[English](./README.md)

Минималистичное WPF-приложение для ведения заметок по багам и задачам. Использует MVVM и локальное хранилище через LiteDB.

---

## ⚙️ Возможности

- Добавление и редактирование **багов** и **задач**
- Структурированные поля:
  - Контакт аналитика
  - Контакт тестировщика
  - Бизнес-процесс
  - Конфигурация и тестовые данные
  - Анализ кода, гипотеза, комментарии
- Статусы:
  - `Proposed`, `Active`, `In PR Review`, `Ready for QA`, `Resolved`
- Чеклист для шагов анализа бага
- Упрощённый интерфейс: главное окно и дополнительное окно
- Все данные хранятся локально в `notes.db` (через LiteDB)

---

## 🗂️ Структура проекта

```
/Models
  - Note.cs (абстрактный)
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

## 🚀 Запуск

1. Клонировать репозиторий:
   ```bash
   git clone https://github.com/lairnan/BugNote-Manager.git
   ```
2. Открыть в Visual Studio
3. Установить зависимости:
   ```bash
   dotnet add package LiteDB
   ```
4. Запустить `MainWindow.xaml`

---

## 📄 Пример модели

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

## 📃 Лицензия

MIT — делай что хочешь.
