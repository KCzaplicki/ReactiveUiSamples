using System;
using System.Threading.Tasks;
using ReactiveUI;
using UIKit;

namespace ReactiveUiInteractions
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

            ViewModel.Confirm.RegisterHandler(async interaction =>
            {
                var result = await ShowConfirmDialogAsync(interaction.Input);
                interaction.SetOutput(result);
            });
            ViewModel.DisplayConfirm("Do you like interactions?");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public Task<bool> ShowConfirmDialogAsync(string confirmText)
        {
            var tcs = new TaskCompletionSource<bool>();

            UIAlertView alertView = new UIAlertView();
            alertView.Message = confirmText;
            alertView.AddButton("Yes");
            alertView.AddButton("No");
            alertView.Dismissed += (sender, e) => tcs.SetResult(e.ButtonIndex == 0);
            alertView.Show();

            return tcs.Task;
        }
    }
}
