using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace GrouppedListReorder.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
        public ObservableCollection<ItemViewModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public ICommand StateAdd { get; }

        public ICommand StateRemove { get; }

        public ICommand StateRemoveAdd { get; }

        public MainPageViewModel()
        {
            StateAdd = new Command(OnStateAdd);
            StateRemove = new Command(OnStateRemove);
            StateRemoveAdd = new Command(OnStateRemoveAdd);
            ResetItemsState();
        }

        private void OnStateAdd()
        {
            Items.Insert(0, new ItemViewModel { Title = $"Item new {Environment.TickCount}" });
            PrintItemsState();
        }

        private void OnStateRemove()
        {
            Items.RemoveAt(4);
            PrintItemsState();
        }

        private void OnStateRemoveAdd()
        {
            Items.RemoveAt(4);
            Items.Insert(0, new ItemViewModel { Title = $"Item new {Environment.TickCount}" });
            PrintItemsState();
        }

        private void ResetItemsState()
        {
            Items.Clear();
            Items.Add(new ItemViewModel { Title = "Item 1" });
            Items.Add(new ItemViewModel { Title = "Item 2" });
            Items.Add(new ItemViewModel { Title = "Item 3" });
            Items.Add(new ItemViewModel { Title = "Item 4" });
            Items.Add(new ItemViewModel { Title = "Item 5" });
            Items.Add(new ItemViewModel { Title = "Item 6" });
            Items.Add(new ItemViewModel { Title = "Item 7" });
        }

        private void PrintItemsState()
        {
            Debug.WriteLine($"Items {Items.Count}, state:");
            for (int i = 0; i < Items.Count; i++)
            {
                Debug.WriteLine($"\t{i}: {Items[i].Title}");
            }
        }
    }
}