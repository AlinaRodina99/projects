module FindNumberInListTests

open NUnit.Framework
open FindNumberInList
open FsUnit

[<Test>] 
let findNumberInListSimpleTest  () =
    findNumber 1 [1; 2; 3] |> should equal (Some(0))
    findNumber 4 [1; 9; 10; 4; 6; 7] |> should equal (Some(3))
    findNumber 3 [1; 20; 40; 4; 50; 3; 3; 3] |> should equal (Some(5))

[<Test>]
let findNumberInEmptyListTest () =
    findNumber 1 [] |> should equal (None)

[<Test>]
let findNonExistentNumberInListTest () =
    findNumber 3 [1; 2; 4; 5] |> should equal (Some(-1))