using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMVVMPatternExample.Utilities
{
    public class MvvmBindableBase : DependencyObject, INotifyPropertyChanged
    {
       
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
       
        /// <summary>
        /// Sets the value of a property if it has changed, and raises the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="field">A reference to the backing field of the property.</param>
        /// <param name="value">The new value for the property.</param>
        /// <param name="propertyName">The name of the property (optional). 
        /// If not provided, the compiler infers it from the calling member's name.</param>
        /// <returns>True if the value has changed; otherwise, false.</returns>

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(field, value)) { return false; }
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }


        /// <summary>
        /// Raises the PropertyChanged event for a property with the specified name.
        /// </summary>
        /// <param name="propertyName">The name of the property to raise the event for. 
        /// If not provided, the compiler infers it from the calling member's name.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the property changed
        /// </summary>
        /// <param name="e"></param>

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
