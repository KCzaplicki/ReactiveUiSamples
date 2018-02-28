using System.Reactive.Linq;
using ReactiveUI;

namespace ReactiveUiOaph
{
    public class MainViewModel : ReactiveObject
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { this.RaiseAndSetIfChanged(ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { this.RaiseAndSetIfChanged(ref lastName, value); }
        }

        readonly ObservableAsPropertyHelper<string> name;
        public string Name
        {
            get { return name.Value; }
        }

        public MainViewModel()
        {
            name = this.WhenAnyValue(x => x.FirstName, x => x.LastName, (firstName, lastName) => $"{firstName} {lastName}")
                            .ToProperty(this, x => x.Name);
        }
    }
}
