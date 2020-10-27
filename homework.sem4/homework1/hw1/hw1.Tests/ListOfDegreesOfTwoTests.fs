module ListOfDegreesOfTwoTests

open NUnit.Framework
open ListOfDegreesOfTwo
open FsUnit

[<Test>]
let ``List of degrees of two several tests`` () =
    listOfDegreesOfTwo 1 2 |> should equal (Some([2; 4; 8]))
    listOfDegreesOfTwo 1 1 |> should equal (Some([2; 4]))
    listOfDegreesOfTwo 2 4 |> should equal (Some([4; 8; 16; 32; 64]))

[<Test>]
let ``List of degrees of  two with n = 0 and m = 0`` () =
    listOfDegreesOfTwo 0 0 |> should equal (Some([1]))

[<Test>]
let ``List of degrees of two when n > m`` () =
    listOfDegreesOfTwo 3 1 |> should equal (Some([8; 16]))
    listOfDegreesOfTwo 10 2 |> should equal (Some([1024; 2048; 4096]))
    listOfDegreesOfTwo 5 3 |> should equal (Some([32; 64; 128; 256]))

[<Test>]
let ``List of degrees of two when n < 0 or m < 0`` () =
    listOfDegreesOfTwo -1 -1 |> should equal (None)
    listOfDegreesOfTwo -1 3 |> should equal (None)
    listOfDegreesOfTwo 3 -2 |> should equal (None)