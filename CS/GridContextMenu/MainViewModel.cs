using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GridContextMenu
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.DeleteCommand = new DelegateCommand<Item>(Delete);
            this.DuplicateCommand = new DelegateCommand<Item>(Duplicate);
        }

        protected ObservableCollection<Item> _Items;

        public ObservableCollection<Item> Items
        {
            get
            {
                if (this._Items == null)
                {
                    this._Items = new ObservableCollection<Item>();
                    Random r = new Random();
                    int i = 0;
                    while (i < 150)
                    {
                        Item value = new Item();
                        value.Name = string.Format("Name #{0}", i);
                        value.Age = r.Next(40) + 20;
                        value.DateTime = DateTime.Today.AddDays(r.Next(30) - 15);
                        value.IsSelected = r.Next(2) > 0;
                        this._Items.Add(value);
                        i = i + 1;
                    }
                }
                return this._Items;
            }
        }


        protected Item _SelectedItem;
        public Item SelectedItem
        {
            get { return this._SelectedItem; }
            set { this.SetProperty(ref this._SelectedItem, value, "SelectedItem"); }
        }

        public DelegateCommand<Item> DeleteCommand { get; private set; }

        public void Delete(Item item)
        {
            if (this.Items.Contains(item))
            {
                var index = this.Items.IndexOf(item);
                this.Items.Remove(item);
                this.SelectedItem = this.Items.Count < index ? this.Items[index] : this.Items.FirstOrDefault();
            }
                
        }

        public DelegateCommand<Item> DuplicateCommand { get; private set; }

        public void Duplicate(Item item)
        {
            var index = this.Items.IndexOf(item);
            var newItem = new Item()
            {
                Name = item.Name,
                Age = item.Age,
                DateTime = item.DateTime,
                IsSelected = item.IsSelected
            };
            this.Items.Insert(index + 1, newItem);
            this.SelectedItem = newItem;
        }
    }
}
