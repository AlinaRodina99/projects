module FibonacciTests

open NUnit.Framework
open Fibonacci
open FsUnit

[<Test>]
[<TestCase(2, 3)>]
[<TestCase(6765, 20)>]
[<TestCase(1, 1)>]
[<TestCase(1, 2)>]
let ``Fibonacci of n several tests`` expected n =
    fibonacci n |> should equal (Some(expected))

[<Test>]
let ``Fibonacci of negative number or zero`` () =
    fibonacci -1 |> should equal (None)
    fibonacci 0 |> should equal (None)

