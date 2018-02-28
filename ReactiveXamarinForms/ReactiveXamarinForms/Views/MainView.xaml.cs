using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveXamarinForms.ViewModels;
using Xamarin.Forms;

namespace ReactiveXamarinForms.Views
{
    public partial class MainView : ContentPageBase<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, false);

            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, x => x.TextProperty, x => x.TextLabel.Text).DisposeWith(SubscriptionDisposables);
                this.BindCommand(ViewModel, x => x.NavigateCommand, x => x.NavigateButton);
            });

            ViewModel.TextProperty = "Hello Reactive World!";
        }
    }
}
