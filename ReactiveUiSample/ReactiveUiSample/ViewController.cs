using System;
using System.Diagnostics;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUiSample.ViewModels;
using UIKit;

namespace ReactiveUiSample
{
    public partial class ViewController : ReactiveViewController, IViewFor<MainViewModel>
    {
        MainViewModel _ViewModel;
        public MainViewModel ViewModel
        {
            get { return _ViewModel; }
            set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return _ViewModel; }
            set { ViewModel = (MainViewModel)value; }
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel = new MainViewModel();

            this.OneWayBind(ViewModel, x => x.TextProperty, x => x.TextLabel.Text);
            this.Bind(ViewModel, x => x.InputProperty, x => x.TextInput.Text);
            this.BindCommand(ViewModel, x => x.TextButtonCommand, x => x.TextButton, "TouchUpInside");
            this.BindCommand(ViewModel, x => x.AlertButtonCommand, x => x.AlertButton, "TouchUpInside");

            ViewModel.TextProperty = "ABC";

            ViewModel.WhenAnyValue(x => x.InputProperty).Subscribe(val => Debug.WriteLine(val));

            this.BindCommand(ViewModel, x => x.NavigateButtonCommand, x => x.NavigationButton, "TouchUpInside");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
