using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OSPing
{
    class SortableBindingList<T> : BindingList<T>
    {
        public SortableBindingList() : base() { }
        public SortableBindingList(IList<T> items) : base(items) { }

        public void Sort(int columnIndex)
        {
            bool original = this.RaiseListChangedEvents;
            this.RaiseListChangedEvents = false;

            List<T> items = (List<T>)this.Items;

            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();

            items = items.OrderBy(item => properties[columnIndex].GetValue(item)).ToList();

            this.ClearItems();

            items.ForEach(item => this.Add(item));

            this.RaiseListChangedEvents = true;
        }
    }
}
