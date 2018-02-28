using System;
using ReactiveUI;

namespace ReactiveUITableView
{
    public partial class CustomCell : ReactiveTableViewCell, IViewFor<ItemViewModel>
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

        public CustomCell(IntPtr handle) : base(handle)
        {
        }

        public void Initialize()
        {
            this.WhenAnyValue(v => v.ViewModel.HeaderProperty).BindTo(this, v => v.HeaderLabel.Text);
            this.WhenAnyValue(v => v.ViewModel.DescriptionProperty).BindTo(this, v => v.DescriptionLabel.Text);
        }
    }
}