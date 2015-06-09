using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System;

namespace OSPing
{
    class DataGridViewAdapter<T>
    {
        private DataGridView _view;

        private SortableBindingList<T> _bindingList;

        public DataGridViewAdapter(DataGridView view)
        {
            _view = view;

            _bindingList = new SortableBindingList<T>();
            _view.DataSource = _bindingList;

            view.RowHeadersVisible = false;
            view.AutoGenerateColumns = true;
        }

        public void Add(T item)
        {
            _bindingList.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            // Workaround to avoid overriding all binding events
            // http://stackoverflow.com/questions/13974617/why-can-i-not-suspend-binding-on-a-bindingsource
            bool originalValue = _bindingList.RaiseListChangedEvents;
            _bindingList.RaiseListChangedEvents = false;
            _bindingList.Clear();
            _bindingList.RaiseListChangedEvents = originalValue;
        }

        public void Sort(int columnIndex)
        {
            _view.DataSource = null;
            _bindingList.Sort(columnIndex);
            _view.DataSource = _bindingList;
            this.ResizeColumns();
        }

        public void ResizeColumns()
        {
            int totalColumns = _view.Columns.Count;

            for (int i = 0; i < totalColumns - 1; i++)
            {
                _view.Columns[i].HeaderText = _view.Columns[i].HeaderText.Replace("_", " ");
                _view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _view.Columns[totalColumns - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < _view.Columns.Count; i++)
            {
                int colw = _view.Columns[i].Width;
                _view.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                _view.Columns[i].Width = colw;
            }
        }
    }
}
