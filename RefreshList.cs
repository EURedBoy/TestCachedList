using System.Collections;
using System.Collections.ObjectModel;

namespace TestCachedList;

public class RefreshList<T> : List<T>
{
    private Timer _timer;
    
    public RefreshList(int seconds, Func<Task<List<T>>> reloadFunction)
    {
        _timer = new Timer(async _ =>
        {
            var data = await reloadFunction.Invoke();
            base.Clear();
            base.AddRange(data);
            //base.Clear();
            //reloadFunction.Invoke().ForEach(element => base.Add(element));
            
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(seconds));
    }

    public new void Add(T item)
    {
        base.Add(item);
    }

    public new bool Remove(T item)
    {
        return base.Remove(item);
    }
}