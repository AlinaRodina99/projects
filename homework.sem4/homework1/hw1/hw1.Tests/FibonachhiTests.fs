module FibonachhiTests

open NUnit.Framework
open Fibonachhi
open FsUnit

[<Test>]
[<TestCase(2, 3)>]
[<TestCase(6765, 20)>]
[<TestCase(1, 1)>]
[<TestCase(1, 2)>]
let FibonachhiSimpleTest expected n =
    fibonachhi n |> should equal (Some(expected))

[<Test>]
let FibonachhiOfNegativeNumberOrZeroTest () =
    fibonachhi -1 |> should equal (None)
    fibonachhi 0 |> should equal (None)

