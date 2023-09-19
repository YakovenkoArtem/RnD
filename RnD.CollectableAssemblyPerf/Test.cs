using BenchmarkDotNet.Attributes;
using System.Reflection;
using System.Reflection.Emit;

namespace RnD.CollectableAssemblyPerf;

[MemoryDiagnoser]
public class Test
{
    public static Type New(AssemblyBuilderAccess aba)
    {
        /*
        В Net Core существует только один app домен. Создание второго и последующих будет падать с ошибкой.
        Что бы иметь возможность выгружать из памяти сгенерированный код, попробуем использовать Collectable сборки.
        Run быстрее RunAndCollect в 10 раз почему то. Попробуем выяснить почему.
        */

        AssemblyName an = new("MyDynamicAssembly");
        AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(an, aba);
        ModuleBuilder mb = ab.DefineDynamicModule("MyDynamicModule");
        TypeBuilder tb = mb.DefineType("MyClass",
                                       TypeAttributes.Public | TypeAttributes.Sealed);

        Type t = tb.CreateType()!;
        return t;
    }

    [Benchmark(Baseline = true)]
    public Type TestCreateNonCollectableClass()
    {
        return New(AssemblyBuilderAccess.Run);
    }

    [Benchmark]
    public Type TestCreateCollectableClass()
    {
        return New(AssemblyBuilderAccess.RunAndCollect);
    }
}