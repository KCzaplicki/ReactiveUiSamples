using System;
using System.Diagnostics;
using ReactiveUI;

namespace ReactiveUiInteractions
{
    public class MainViewModel : ReactiveObject
    {
        private readonly Interaction<string, bool> confirm;

        public Interaction<string, bool> Confirm => this.confirm;

        public MainViewModel()
        {
            this.confirm = new Interaction<string, bool>();
        }

        public void DisplayConfirm(string confirmText){
            var confirmObservable = this.confirm.Handle(confirmText);
            confirmObservable.Subscribe(result => Debug.WriteLine($"User response for question '{confirmText}' is {result}"));
        }
    }
}
