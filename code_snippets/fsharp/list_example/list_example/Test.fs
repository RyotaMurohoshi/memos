namespace list_example
open System
open NUnit.Framework

[<TestFixture>]
type Test() = 

    let double n = n * 2
    let isEven n = n % 2 = 0

    [<Test>]
    member x.TestMap() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.map double, [2; 4; 6; 8; 10])

    [<Test>]
    member x.TestFilter() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.filter isEven, [2; 4])


    [<Test>]
    member x.TestForAll() =
        Assert.IsFalse([1; 2; 3; 4; 5] |> List.forall isEven)
        Assert.IsTrue([1; 2; 3; 4; 5] |> List.map double |> List.forall isEven)

    [<Test>]
    member x.TestExists() =
        Assert.IsTrue([1; 2; 3; 4; 5] |> List.exists isEven)
        Assert.IsFalse([1; 2; 3; 4; 5] |> List.exists (fun n -> n = 0))
