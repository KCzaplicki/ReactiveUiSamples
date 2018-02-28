using System;
using ReactiveUI;
using UIKit;

namespace ReactiveUITableView
{
    public class Cell : ReactiveTableViewCell, IViewFor<ItemViewModel>
    {
        private ItemViewModel _viewModel;
        public ItemViewModel ViewModel
        {
            get { return _viewModel; }
            set { this.RaiseAndSetIfChanged(ref _viewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value as ItemViewModel; }
        }

        public Cell(IntPtr handle) : base(handle)
        {
        }

        public void Initialize()
        {
            this.WhenAnyValue(v => v.ViewModel.TextProperty).BindTo(this, v => v.TextLabel.Text);
        }
    }
}