namespace list_example
open System
open NUnit.Framework

[<TestFixture>]
type Test() =

    let double n = n * 2
    let isEven n = n % 2 = 0
    let isZero n = n = 0

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
        Assert.IsFalse([1; 2; 3; 4; 5] |> List.exists isZero)

    [<Test>]
    member x.TestFind() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.find isEven, 2)

    [<Test>]
    member x.TestFindIndex() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.findIndex isEven, 1)

    [<Test>]
    [<ExpectedException("System.Collections.Generic.KeyNotFoundException")>]
    member x.TestFindIndex_Exception() =
        [1; 2; 3; 4; 5] |> List.findIndex isZero

    [<Test>]
    [<ExpectedException("System.Collections.Generic.KeyNotFoundException")>]
    member x.TestFind_Exception() =
        [1; 2; 3; 4; 5] |> List.find isZero

    [<Test>]
    member x.TestFindBack() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.findBack isEven, 4)

    [<Test>]
    [<ExpectedException("System.Collections.Generic.KeyNotFoundException")>]
    member x.TestFindLast_Exception() =
        [1; 2; 3; 4; 5] |> List.findBack isZero

    [<Test>]
    member x.TestFindIndexBack() =
        Assert.AreEqual([1; 2; 3; 4; 5] |> List.findIndexBack isEven, 3)

    [<Test>]
    [<ExpectedException("System.Collections.Generic.KeyNotFoundException")>]
    member x.TestFindIndexBack_Exception() =
        [1; 2; 3; 4; 5] |> List.findIndexBack isZero
