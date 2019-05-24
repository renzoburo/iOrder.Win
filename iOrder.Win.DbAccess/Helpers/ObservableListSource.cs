namespace iOrder.Win.DbAccess.Helpers
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Data.Entity;

    public class ObservableListSource<T> : ObservableCollection<T>, IListSource
        where T : class
    {
        IBindingList bindingList;

        public bool ContainsListCollection => false;

        public IList GetList()
        {
            return bindingList ?? (bindingList = this.ToBindingList());
        }
    }
}
