module ReverseListTest

open NUnit.Framework
open ReverseList

[<Test>]
let ReverseListSimpleTests () =
    Assert.AreEqual(Some([3; 2; 1]), reverseList [1; 2; 3])
    Assert.AreEqual(Some([26; 25; 20; 9; 6; 4; 0; 13; 11; 5; 2]), reverseList [2; 5; 11; 13; 0; 4; 6; 9; 20; 25; 26])
    Assert.AreEqual(Some([7; 6; 5]), reverseList [5; 6; 7])
    Assert.AreEqual(Some([1; 3; 67; 8]), reverseList [8; 67; 3; 1])

let ReverseEmptyList () =
    Assert.AreEqual(Some([]), reverseList [])
