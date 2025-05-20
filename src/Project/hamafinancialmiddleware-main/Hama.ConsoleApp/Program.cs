using Hama.Share.Models.Mock;
using Hama.Share.Tools;

//int rows = 50_000;
//int columns = 1000;

//Task.Run(() =>
//{
//    var watch1 = System.Diagnostics.Stopwatch.StartNew();
//    Console.WriteLine("Generating DataTable...");
//    var dt = MockGenerator.GenerateLargeDataTable(rows, columns);
//    watch1.Stop();
//    Console.WriteLine($"DataTable generation completed in: {watch1.ElapsedMilliseconds / 1000.0} seconds.");

//});
//object ls;
//Task.Run(() =>
//{
//    var watch2 = System.Diagnostics.Stopwatch.StartNew();
//    Console.WriteLine("Generating List...");
//    var list = MockGenerator.GenerateLargeList(rows, columns);
//    ls = list;
//    watch2.Stop();
//    Console.WriteLine($"List generation completed in: {watch2.ElapsedMilliseconds / 1000.0} seconds.");
//});

await Task.Run(() =>
{
    IEnumerable<HealthInsurancePolicy> Policies = new List<HealthInsurancePolicy>();
    var watch3 = System.Diagnostics.Stopwatch.StartNew();
    Console.WriteLine("************************************************");
    Console.WriteLine("Generating Policy List...");
    Console.WriteLine($"Policy Property Count : {new Person().GetType().GetProperties().Count()}");
    Policies =  MockGenerator.GenerateMockPolicies(1_000_000).GetAwaiter().GetResult();
    Console.WriteLine($"Policy Count : {Policies.Count().ToString("n0")}");
    watch3.Stop();
    Console.WriteLine($"Policy List generation completed in: {watch3.ElapsedMilliseconds / 1000.0} seconds.");
    Console.WriteLine("************************************************");
    watch3.Restart();
    System.Data.DataTable dt =  FastDataTableConverter.ToDataTableAsync(Policies).GetAwaiter().GetResult();
    Console.WriteLine($"DataTable Count : {dt.Rows.Count.ToString("n0")}");
    Console.WriteLine($"Policy List Convert To DataTable completed in: {watch3.ElapsedMilliseconds / 1000.0} seconds.");
    Console.WriteLine("************************************************");
    watch3.Restart();
    var ls = FastDataTableConverter.ToList<Person>(dt);
    Console.WriteLine($"DataTable Count : {dt.Rows.Count.ToString("n0")}");
    Console.WriteLine($"Policy DataTable  Convert ToList completed in: {watch3.ElapsedMilliseconds / 1000.0} seconds.");
    Console.WriteLine("************************************************");
});

Console.WriteLine("Done.");
Console.ReadLine();