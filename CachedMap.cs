namespace TestCachedList;

public class CachedMap<T, R> where T : notnull
{
    private int time;
    private Func<T, Task<R>> retriveData;
    
    private Dictionary<T, R?> dataMap;
    private Dictionary<T, Timer> timerMap;

    public CachedMap(Func<T, Task<R>> retriveData, int time)
    {
        dataMap = new Dictionary<T, R?>();
        timerMap = new Dictionary<T, Timer>();

        this.time = time;
        this.retriveData = retriveData;
    }

    public R? this[T index]
    {
        get
        {
            if (!timerMap.ContainsKey(index))
                timerMap.Add(index, new Timer(async _ =>
                {
                    dataMap.Remove(index);
                
                    await timerMap[index].DisposeAsync();
                    timerMap.Remove(index);
                }, null, TimeSpan.FromSeconds(time), TimeSpan.Zero));
            
            if (!dataMap.ContainsKey(index)) dataMap.Add(index, retriveData.Invoke(index).Result);

            return dataMap[index];
        }
    }
    
    
}