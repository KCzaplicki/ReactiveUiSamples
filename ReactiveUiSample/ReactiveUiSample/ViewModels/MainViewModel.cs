using System.Diagnostics;
using System.Reactive;
using ReactiveUI;
using UIKit;

namespace ReactiveUiSample.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private string textProperty;
        public string TextProperty
        {
            get { return textProperty; }
            set { this.RaiseAndSetIfChanged(ref textProperty, value); }
        }

        private string inputProperty;
        public string InputProperty
        {
            get { return inputProperty; }
            set { this.RaiseAndSetIfChanged(ref inputProperty, value); }
        }

        private bool navigateToSecondViewController;
        public bool NavigateToSecondViewController
        {
            get { return NavigateToSecondViewController; }
            set { this.RaiseAndSetIfChanged(ref navigateToSecondViewController, value); }
        }

        private readonly ReactiveCommand<Unit, Unit> textButtonCommand;
        public ReactiveCommand<Unit, Unit> TextButtonCommand => this.textButtonCommand;

        private readonly ReactiveCommand<Unit, Unit> alertButtonCommand;
        public ReactiveCommand<Unit, Unit> AlertButtonCommand => this.alertButtonCommand;

        private readonly ReactiveCommand<Unit, Unit> navigateButtonCommand;
        public ReactiveCommand<Unit, Unit> NavigateButtonCommand => this.navigateButtonCommand;

        public MainViewModel()
        {
            this.textButtonCommand = ReactiveCommand.Create(() => Debug.WriteLine(textProperty));
            this.alertButtonCommand = ReactiveCommand.Create(() => {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;

                var alertController = UIAlertController.Create("Alert Controller", inputProperty, UIAlertControllerStyle.Alert);  
                alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alert => alert.Dispose()));
                vc.PresentViewController(alertController, true, null);
            });
            this.navigateButtonCommand = ReactiveCommand.Create(() => {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                               
                var secondViewController = vc.Storyboard.InstantiateViewController("SecondViewController");
                vc.PresentViewController(secondViewController, true, null);
            });
        }
    }
}
