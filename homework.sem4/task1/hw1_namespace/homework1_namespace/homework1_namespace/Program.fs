open System

[<EntryPoint>]
let main argv =
    
    let rec Factorial n acc = 
        match n with
        | _ when n < 0 -> None
        | 0 | 1 -> acc
        | _ -> Factorial (n - 1) (acc * n)
    0
        


