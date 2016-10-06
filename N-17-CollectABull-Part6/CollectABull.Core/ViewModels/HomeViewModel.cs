using CollectABull.Core.Services.Collections;
using CollectABull.Core.Services.DataStore;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace CollectABull.Core.ViewModels
{
    public class HomeViewModel 
		: MvxViewModel
    {
        private readonly ICollectionService _collectionService;
        private MvxSubscriptionToken _collectionChangedSubscriptionToken;

        public HomeViewModel(ICollectionService collectionService, IMvxMessenger messenger)
        {
            _collectionService = collectionService;
            _collectionChangedSubscriptionToken = messenger.Subscribe<CollectionChangedMessage>(OnCollectionChanged);
            UpdateLatest();
        }

        private void OnCollectionChanged(CollectionChangedMessage obj)
        {
            UpdateLatest();
        }

        private void UpdateLatest()
        {
            Latest = _collectionService.Latest;
        }

        private CollectedItem _latest;
        public CollectedItem Latest
        {
            get { return _latest; }
            set { _latest = value; RaisePropertyChanged(() => Latest); }
        }

        private MvxCommand _addCommnad;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                _addCommnad = _addCommnad ?? new MvxCommand(DoAdd);
                return _addCommnad;
            }
        }

        private void DoAdd()
        {
            ShowViewModel<AddViewModel>();
        }

        private MvxCommand _listCommand;

        public System.Windows.Input.ICommand ListCommand
        {
            get
            {
                _listCommand = _listCommand ?? new MvxCommand(DoList);
                return _listCommand;
            }
        }

        private void DoList()
        {
            ShowViewModel<ListViewModel>();
        }                
    }
}
