using DevExpress.Mvvm;
using System;

namespace GridContextMenu
{

    public class Item : BindableBase
    {
        protected string _Name;
        public string Name
        {
            get { return this._Name; }
            set { this.SetProperty(ref this._Name, value, "Name"); }
        }

        protected int _Age;
        public int Age
        {
            get { return this._Age; }
            set { this.SetProperty(ref this._Age, value, "Age"); }
        }

        protected DateTime _DateTime;
        public DateTime DateTime
        {
            get { return this._DateTime; }
            set { this.SetProperty(ref this._DateTime, value, "DateTime"); }
        }

        protected bool _IsSelected;
        public bool IsSelected
        {
            get { return this._IsSelected; }
            set { this.SetProperty(ref this._IsSelected, value, "IsSelected"); }
        }
    }
}
