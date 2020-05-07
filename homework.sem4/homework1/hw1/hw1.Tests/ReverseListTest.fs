module ReverseListTest

open NUnit.Framework
open ReverseList
open FsUnit

[<Test>]
let ``Reverse list several tests`` () =
    reverseList [1; 2; 3] |> should equal (Some([3; 2; 1]))
    reverseList [2; 5; 11; 13; 0; 4; 6; 9; 20; 25; 26] |> should equal (Some([26; 25; 20; 9; 6; 4; 0; 13; 11; 5; 2]))
    reverseList [5; 6; 7] |> should equal (Some([7; 6; 5]))
    reverseList [8; 67; 3; 1] |> should equal (Some([1; 3; 67; 8]))

let ReverseEmptyList () =
    reverseList [] |> should equal (Some([]))
