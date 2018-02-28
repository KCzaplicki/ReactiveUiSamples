using System;
using System.Reactive;
using ReactiveUI;

namespace ReactiveXamarinForms.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        string textProperty;
        public string TextProperty
        {
            get { return textProperty; }
            set { this.RaiseAndSetIfChanged(ref textProperty, value); }
        }

        private readonly ReactiveCommand<Unit, Unit> navigateCommand;
        public ReactiveCommand<Unit, Unit> NavigateCommand => this.navigateCommand;

        public MainViewModel(IScreen hostScreen = null) : base(hostScreen)
        {
            this.navigateCommand = ReactiveCommand.Create(() => 
            {
                HostScreen.Router.Navigate.Execute(new SecondViewModel()).Subscribe();   
            }); 
        }
    }
}
