using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Messaging;
using Hangfire.Annotations;

namespace DropDownMenu.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private IMessenger _messengerInstance;

        protected IMessenger MessengerInstance
        {
            get { return _messengerInstance ?? Messenger.Default; }
            set { _messengerInstance = value; }
        }

        public virtual void Cleanup()
        {
            MessengerInstance.Unregister(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [NotifyPropertyChangedInvocator]
        public virtual void RaisePropertyChanged<T>(Expression<Func<T>> expression)
        {
            var propertyChangedEventHandler = PropertyChanged;
            if (propertyChangedEventHandler == null) return;

            var propertyName = PropertyHelper.ExtractPropertyName(expression);
            propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
