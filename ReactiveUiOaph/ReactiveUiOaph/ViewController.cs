using System;
using ReactiveUI;

namespace ReactiveUiOaph
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
            ViewModel = new MainViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Bind(ViewModel, x => x.FirstName, x => x.FirstNameTextField.Text);
            this.Bind(ViewModel, x => x.LastName, x => x.LastNameTextField.Text);
            this.Bind(ViewModel, x => x.Name, x => x.NameLabel.Text);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
