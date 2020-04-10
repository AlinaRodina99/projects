module Fibonachhi

///function to find the Fibonachhi number
let fibonachhi n =
    match n with 
    | _ when n <= 0 -> None
    | 1 | 2 -> Some(1)
    | _ -> let rec recursiveFibonachhi acc x y i = 
               match i with 
               | _ when i = n -> Some(acc)
               | _ -> recursiveFibonachhi (x + y) y (x + y) (i + 1)
           recursiveFibonachhi 0 1 1 2
           
