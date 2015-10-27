using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using StockoutIndexBuilder.Models;

namespace PharmInventory.ViewModel
{
    class ItemViewModelCollection : ICollection<ItemViewModel>
    {
        private ArrayList _collection = new ArrayList();

        public void Add(ItemViewModel item)
        {
            _collection.Add(item);
        }

        public void Remove(ItemViewModel item)
        {
            _collection.Remove(item);
        }

        public ItemViewModel this[int index]
        {
            get { return (ItemViewModel)_collection.ToArray()[index]; }
            set { _collection.Insert(index, value); }
        }


        public void Clear()
        {
            _collection = new ArrayList();
        }

        public bool Contains(ItemViewModel item)
        {
            return _collection.IndexOf(item) != -1;
        }

        public void CopyTo(ItemViewModel[] array, int arrayIndex)
        {
            for (int i = 0, j = arrayIndex; i < Count; i++, j++)
            {
                array[j] = this[i];
            }
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<ItemViewModel>.Remove(ItemViewModel item)
        {
            Remove(item);
            return true;
        }

        public IEnumerator<ItemViewModel> GetEnumerator()
        {
            //return new ItemsEnumerator(_collection);
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
            
        }

        public static List<ItemViewModel> Create(IEnumerable<Item> items)
        {
            var collection = new List<ItemViewModel>();
            foreach (var item in items)
            {
                var viewModel = new ItemViewModel(item);
                collection.Add(viewModel);
            }
            return collection;
        }
    }

    public class ItemsEnumerator : IEnumerator
    {
        public ItemViewModel[] _items;

        // Enumerators are positioned before the first element 
        // until the first MoveNext() call. 
        int position = -1;

        public ItemsEnumerator(ArrayList list)
        {
            _items = new ItemViewModel[list.Count];
            for(int i=0;i<list.Count;i++)
            {
                _items[i] = list[i] as ItemViewModel;
            }            
        }

        public bool MoveNext()
        {
            position++;
            return (position < _items.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public ItemViewModel Current
        {
            get
            {
                try
                {
                    return _items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
