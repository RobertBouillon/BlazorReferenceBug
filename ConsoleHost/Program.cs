using System;
using System.Threading.Tasks;

namespace ConsoleHost
{
  class Program
  {
    static void Main(string[] args)
    {
      //RunBlazor();
      RunMVC();
      Console.Read();
    }

    private static void RunBlazor() => Task.Run(SafeRunBlazor);
    private static void RunMVC() => Task.Run(SafeRunMVC);

    private static async Task SafeRunBlazor()
    {
      try
      {
        await BlazorReferenceBug.Program.Main(Array.Empty<String>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        throw;
      }
    }

    private static void SafeRunMVC()
    {
      try
      {
        MVCSite.Program.Main(Array.Empty<string>());
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        throw;
      }
    }
  }
}
