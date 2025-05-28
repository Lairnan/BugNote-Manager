using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BugNoteManager.Interfaces.Models;

public interface IDataCollectionView<T> : ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
{
    Predicate<T>? FilterPredicate { get; set; }
    void Refresh();
    void SortBy(Func<T, IComparable> sortPredicate);
    void SortBy(IEnumerable<T> firstCollection);
    
    bool IsEmpty { get; }
}