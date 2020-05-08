module ListEvenNumbersWithMap

let mapEvenNumbers list = list |> List.map (fun x -> x % 2 = 0 |> List.length)