module FindNumberInListTests

open NUnit.Framework
open FindNumberInList

[<Test>] 
let FindNumberInListSimpleTests  () =
    Assert.AreEqual(Some(0), findNumber 1 [1; 2; 3])
    Assert.AreEqual(Some(3), findNumber 4 [1; 9; 10; 4; 6; 7])
    Assert.AreEqual(Some(5), findNumber 3 [1; 20; 40; 4; 50; 3; 3; 3])

[<Test>]
let FindNumberInEmptyListTest () =
    Assert.AreEqual(None, findNumber 1 [])

[<Test>]
let FindNonExistentNumberInListTest () =
    Assert.AreEqual(Some(-1), findNumber 3 [1; 2; 4; 5])