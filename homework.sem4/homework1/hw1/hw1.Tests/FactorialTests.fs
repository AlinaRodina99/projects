module hw1.Tests

open NUnit.Framework
open Factorial

[<Test>]
[<TestCase(6, 3)>]
[<TestCase(3628800, 10)>]
[<TestCase(720, 6)>]
[<TestCase(1, 1)>]
[<TestCase(1, 0)>]
let FactorialSimpleTest expected x =
    Assert.AreEqual(Some(expected), factorial x)

[<Test>]
let FactorialOfNegativeNumbersTest () =
    Assert.AreEqual(None, factorial -1)
