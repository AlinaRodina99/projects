module FibonachhiTests

open NUnit.Framework
open Fibonachhi

[<Test>]
[<TestCase(2, 3)>]
[<TestCase(6765, 20)>]
[<TestCase(1, 1)>]
[<TestCase(1, 2)>]
let FibonachhiSimpleTest expected n =
    Assert.AreEqual(Some(expected), fibonachhi n)

[<Test>]
let FibonachhiOfNegativeNumberOrZeroTest () =
    Assert.AreEqual(None, fibonachhi -1)
    Assert.AreEqual(None, fibonachhi 0)

