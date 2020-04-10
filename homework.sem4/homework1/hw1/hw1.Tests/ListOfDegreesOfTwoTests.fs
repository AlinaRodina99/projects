module ListOfDegreesOfTwoTests

open NUnit.Framework
open ListOfDegreesOfTwo

[<Test>]
let ListOfDegreesOfTwoSimpleTests () =
    Assert.AreEqual(Some([2; 4; 8]), listOfDegreesOfTwo 1 2)
    Assert.AreEqual(Some([2; 4]), listOfDegreesOfTwo 1 1)
    Assert.AreEqual(Some([4; 8; 16; 32; 64]), listOfDegreesOfTwo 2 4)

[<Test>]
let ListOfDegreesOfTwoWithZeroNAndM () =
    Assert.AreEqual(Some([1]), listOfDegreesOfTwo 0 0)

[<Test>]
let ListOfDegreesOfTwoWhenNIsBiggerThanM () =
    Assert.AreEqual(Some([8; 16]), listOfDegreesOfTwo 3 1)
    Assert.AreEqual(Some([1024; 4096]), listOfDegreesOfTwo 10 2)
    Assert.AreEqual(Some([32; 256]), listOfDegreesOfTwo 5 3)

[<Test>]
let ListOfDegreesOfTwoWhenNOrMIsUnderZero () =
    Assert.AreEqual(None, listOfDegreesOfTwo -1 -1)
    Assert.AreEqual(None, listOfDegreesOfTwo -1 3)
    Assert.AreEqual(None, listOfDegreesOfTwo 3 -2)