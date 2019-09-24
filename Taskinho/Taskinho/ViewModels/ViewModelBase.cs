using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using Taskinho.Model;

namespace Taskinho.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public void NotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)  
        {
            sender = new ObservableCollection<Tarefa>();
            
            switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                    CollectionChanged.Invoke(sender, e);
                        break;

                    case NotifyCollectionChangedAction.Move:
                    CollectionChanged.Invoke(sender, e);
                    break;

                    case NotifyCollectionChangedAction.Remove:
                    CollectionChanged.Invoke(sender, e);
                    break;

                    case NotifyCollectionChangedAction.Replace:
                    CollectionChanged.Invoke(sender, e);
                    break;

                    case NotifyCollectionChangedAction.Reset:
                    CollectionChanged.Invoke(sender, e);
                    break;

                    default:
                        throw new NotImplementedException();
                }
            }
    }
}
