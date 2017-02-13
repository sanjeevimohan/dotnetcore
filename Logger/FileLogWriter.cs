using System.IO;
using System.Text;
public class FileLogWriter : BaseLogWriter 
{ 
  readonly string CRLF = "\r\n";
  string fileName; 
  public FileLogWriter(string fileName){ 
    this.fileName =  fileName; 
  } 
  public override bool WriteToMedia( string content) 
  { 
    using (var stream = File.Open(fileName, FileMode.Append )) 
    { 
      var buffer = Encoding.UTF8.GetBytes(content + CRLF); 
      stream.Write (buffer, 0, buffer.Length); 
    } 
    return true; 
  }
}