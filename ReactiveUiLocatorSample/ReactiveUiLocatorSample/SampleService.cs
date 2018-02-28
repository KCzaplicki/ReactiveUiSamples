using Splat;

namespace ReactiveUiLocatorSample
{
    public class SampleService : ISampleService
    {
        ISampleDependency _sampleDependency;

        public SampleService()
        {
            _sampleDependency = Locator.Current.GetService<ISampleDependency>();
        }

        public string Foo()
        {
            var dependencyFoo = _sampleDependency.Foo();

            return $"{dependencyFoo} - Foo method";
        }
    }
}
