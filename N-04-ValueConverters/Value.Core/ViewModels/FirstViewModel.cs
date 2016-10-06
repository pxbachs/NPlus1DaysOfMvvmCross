using MvvmCross.Core.ViewModels;

namespace Value.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        private string _foo = "Hello MvvmCross";
        public string Foo
        { 
            get { return _foo; }
            set { SetProperty (ref _foo, value); }
        }
    }
}
