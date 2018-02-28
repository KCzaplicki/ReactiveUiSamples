using System;
using ReactiveUI;

namespace ReactiveUITableView
{
    public class ItemViewModel : ReactiveObject
    {
        private string headerProperty;
        public string HeaderProperty
        {
            get { return headerProperty; }
            set { this.RaiseAndSetIfChanged(ref headerProperty, value); }
        }

        private string descriptionProperty;
        public string DescriptionProperty
        {
            get { return descriptionProperty; }
            set { this.RaiseAndSetIfChanged(ref descriptionProperty, value); }
        }
    }
}
