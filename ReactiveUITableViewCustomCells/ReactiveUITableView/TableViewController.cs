using System;
using System.Reactive.Linq;
using Foundation;
using ReactiveUI;
using UIKit;

namespace ReactiveUITableView
{
    public partial class TableViewController : ReactiveTableViewController, IViewFor<MainViewModel>
    {
        private MainViewModel viewModel;
        private readonly NSString CellId = new NSString("CellId");
        private const float CellHeight = 46;

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

            this.WhenAnyValue(x => x.ViewModel)
                .Where(x => x != null)
                .Select(x => new ReactiveTableViewSource<ItemViewModel>(TableView, x.Items, CellId, CellHeight, c => ((CustomCell)c).Initialize()))
                .BindTo(TableView, x => x.Source);
        }
    }
}