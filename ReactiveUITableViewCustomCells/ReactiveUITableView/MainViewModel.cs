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
                HeaderProperty = "Text A",
                DescriptionProperty = "Description"
            });
            this.items.Add(new ItemViewModel
            {
                HeaderProperty = "Text B",
                DescriptionProperty = "Description"
            });
            this.items.Add(new ItemViewModel
            {
                HeaderProperty = "Text C",
                DescriptionProperty = "Description"
            });
        }

        public IReactiveList<ItemViewModel> Items => this.items;
    }
}
