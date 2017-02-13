using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
public abstract class BaseLogWriter : ILogWriter
{
  readonly int QUEUE_THRESHOLD = 2;
  ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
  Object _lock = new Object(); 
  async Task Flush()
  {
    string content; 
    int count = 0; 
    while (queue.TryDequeue(out content) && count <= QUEUE_THRESHOLD) 
    { 
      // Write to Appropriate Media 
      // Calls the Overriden method 
      WriteToMedia(content); 
      count++; 
    } 
  }

  public async Task<bool> Write(string content)
  {
    queue.Enqueue(content);
    if (queue.Count <= QUEUE_THRESHOLD) 
    return true; 
    lock (_lock){ 
      Task temp = Task.Run(() => Flush()); 
      Task.WaitAll(new Task[] { temp }); 
    } 
    return true;
  }

  public abstract bool WriteToMedia(string content);
}