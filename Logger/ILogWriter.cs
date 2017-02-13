using System.Threading.Tasks;
public interface ILogWriter
{
  Task<bool> Write(string content);
}