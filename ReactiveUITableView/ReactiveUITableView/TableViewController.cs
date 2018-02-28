using Foundation;
using System;
using UIKit;
using ReactiveUI;
using System.Reactive.Linq;

namespace ReactiveUITableView
{
    public partial class TableViewController : ReactiveTableViewController, IViewFor<MainViewModel>
    {
        private MainViewModel viewModel;

        public MainViewModel ViewModel
        {
            get { return this.viewModel; }
            set { this.RaiseAndSetIfChanged(ref this.viewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return this.ViewModel; }
            set { this.ViewModel = (MainViewModel)value; }
        }

        public TableViewController (IntPtr handle) : base (handle)
        {
            this.ViewModel = new MainViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel.WhenAnyValue(vm => vm.Items).BindTo<ItemViewModel, Cell>(TableView, 46, cell => cell.Initialize());
        }
    }
}