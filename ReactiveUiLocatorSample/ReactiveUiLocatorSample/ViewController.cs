using System;
using ReactiveUI;
using Splat;

namespace ReactiveUiLocatorSample
{
    public partial class ViewController : ReactiveViewController, IViewFor<MainViewModel>
    {
        ISampleService _sampleService;

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
            _sampleService = Locator.Current.GetService<ISampleService>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TextLabel.Text = _sampleService.Foo();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
