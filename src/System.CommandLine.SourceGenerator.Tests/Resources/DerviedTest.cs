using System;
using System.IO;
using System.Threading.Tasks;
using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

public abstract class DerviedTest_Base
{
    [Option("--option")]
    public int Option { get; set; }

    [Option("--virtual-has-option")]
    public virtual int VirtualHasOption { get; set; }

    public virtual int VirtualNoOption { get; set; }
}

[RootCommand]
public class DerviedTest : DerviedTest_Base
{
    [Option("--virtual-has-option-override")]
    public override int VirtualHasOption { get; set; }
    
    [Option("--virtual-no-option")]
    public override int VirtualNoOption { get; set; }
}
