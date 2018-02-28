using System;
using ReactiveUI;

namespace ReactiveUITableView
{
    public class MainViewModel : ReactiveObject
    {
        private readonly IReactiveList<ItemViewModel> items;

        public MainViewModel()
        {
            this.items = new ReactiveList<ItemViewModel>();
            this.items.Add(new ItemViewModel
            {
                TextProperty = "Text A"
            });
            this.items.Add(new ItemViewModel
            {
                TextProperty = "Text B"
            });
            this.items.Add(new ItemViewModel
            {
                TextProperty = "Text C"
            });
        }

        public IReactiveList<ItemViewModel> Items => this.items;
    }
}
