module Factorial

///function to calculate the factorial of the number
let factorial x =
    let rec recursiveFactorial x acc =
        match x with 
        | _ when x < 0 -> None
        | _ when x = 0 -> Some(1)
        | _ when x = 1 -> Some(acc)
        | _ -> recursiveFactorial (x - 1) (acc * x)
    recursiveFactorial x 1