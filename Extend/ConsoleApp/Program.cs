
Console.WriteLine("Hej världen SWETUGG 2024!");

Wasmtime.WasiConfiguration conf = new Wasmtime.WasiConfiguration()
    .WithInheritedStandardError()
    .WithInheritedStandardOutput()
    .WithArg("CalledFromConsole")
    .WithArgs(args); //passing args

var engineConfig = new Wasmtime.Config();
//engineConfig.WithFuelConsumption(true);
var engine = new Wasmtime.Engine(engineConfig);
var linker = new Wasmtime.Linker(engine);
linker.DefineWasi();
var store = new Wasmtime.Store(engine);
store.SetWasiConfiguration(conf);
//store.Fuel = 20000; 

string wasm = @"wasm/myrustmodule.wasm";
var module = Wasmtime.Module.FromFile(engine, wasm);
var inst = linker.Instantiate(store, module);
var main = inst.GetFunction("main");

if (main!=null)
    main.Invoke(0,0);

//Console.WriteLine($"Consumed fuel: {store.Fuel}");