
using System.Diagnostics;
using Astro.Core;

VirtualMachine vm = new VirtualMachine();
ProgramWriter writer = new ProgramWriter();
var a = writer.Constant(10);
var b = writer.Constant(20.5f);
writer.Move(a, VirtualMachine.AReg);
writer.Move(b, VirtualMachine.BReg);
writer.Add();
writer.Copy(VirtualMachine.CReg, VirtualMachine.AReg);
writer.Print();
writer.Return();
writer.Write(vm);

Stopwatch sw = Stopwatch.StartNew();
vm.Interpret();
sw.Stop();
Console.WriteLine($"\nInterpretation took {sw.ElapsedMilliseconds}ms");