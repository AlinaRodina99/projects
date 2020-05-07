module Fibonachhi

///<summary> Function to find certain Fibonacci number.</summary>
let fibonacci n =
    match n with 
    | _ when n <= 0 -> None
    | 1 | 2 -> Some(1)
    | _ -> let rec recursiveFibonacci x acc i = 
               match i with 
               | _ when i = n -> Some(acc)
               | _ -> recursiveFibonacci acc (x + acc) (i + 1)
           recursiveFibonacci 1 1 2
           
