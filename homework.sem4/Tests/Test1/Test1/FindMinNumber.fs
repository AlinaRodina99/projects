module FindMinNumber

///function to find minimum in list
let findMinNumberInList list =
    
    ///function to define which element is smaller
    let minNumber x y =
        match x with 
        | _ when x <= y -> x
        | _ -> y

    let minNumberInList list = List.reduce minNumber list

    if list = [] then 
        None
    else 
        minNumberInList list

