module hw1.Tests

open NUnit.Framework
open Factorial
open FsUnit

[<Test>]
[<TestCase(6, 3)>]
[<TestCase(3628800, 10)>]
[<TestCase(720, 6)>]
[<TestCase(1, 1)>]
[<TestCase(1, 0)>]
let FactorialSimpleTest expected x =
    factorial x |> should equal (Some(expected))

[<Test>]
let FactorialOfNegativeNumbersTest () =
    factorial -1 |> should equal (None)]
