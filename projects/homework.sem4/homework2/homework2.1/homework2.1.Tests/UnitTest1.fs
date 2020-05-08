module homework2._1.Tests

open NUnit.Framework
open FsUnit
open ListEvenNumbersWithMap

[<Test>]
let ``test`` () =
    mapEvenNumbers [1; 3; 2; 5; 6] |> should equal (2)
