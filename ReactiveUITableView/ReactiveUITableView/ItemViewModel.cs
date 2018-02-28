using System;
using ReactiveUI;

namespace ReactiveUITableView
{
    public class ItemViewModel : ReactiveObject
    {
        private string textProperty;
        public string TextProperty
        {
            get { return textProperty; }
            set { this.RaiseAndSetIfChanged(ref textProperty, value); }
        }
    }
}
