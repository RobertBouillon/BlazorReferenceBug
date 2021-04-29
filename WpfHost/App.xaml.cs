using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfHost
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    protected override void OnStartup(StartupEventArgs e)
    {
      RunBlazor();
      //RunMVC();
      base.OnStartup(e);
    }

    private void RunBlazor() => Task.Run(SafeRunBlazor);
    private void RunMVC() => Task.Run(SafeRunMVC);

    private static async Task SafeRunBlazor()
    {
      try
      {
        await BlazorReferenceBug.Program.Main(Array.Empty<String>());
      }
      catch (Exception ex)
      {
        Trace.WriteLine(ex);
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
        Trace.WriteLine(ex);
        throw;
      }
    }
  }
}
