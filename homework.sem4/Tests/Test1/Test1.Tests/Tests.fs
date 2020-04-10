module Test1.Tests

open NUnit.Framework
open FindMinNumber

[<Test>]
let FindNumberInListSimpleTest () =
    Assert.AreEqual(Some(1), findMinNumberInList [Some(1); Some(2); Some(3)])

[<Test>]
let FindNumberInEmptyListTest () =
    Assert.AreEqual(None, findMinNumberInList [])

[<Test>]
let FindNumberInListWhereAreDuplicates () =
    Assert.AreEqual(Some(2), findMinNumberInList [Some(2); Some(2); Some(45); Some(50)])

