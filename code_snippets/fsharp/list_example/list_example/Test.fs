namespace list_example
open System
open NUnit.Framework

[<TestFixture>]
type Test() = 

    [<Test>]
    member x.TestMap() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.map (fun n -> n * 2), [2; 4; 6; 8; 10])

    [<Test>]
    member x.TestFilter() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.filter (fun n -> n % 2 = 0), [2; 4])
