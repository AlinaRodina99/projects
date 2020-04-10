module FindNumberInList

///function to find the first position in the list of the specified number
let findNumber x list =
    let rec recursiveFindNumber acc list =
        if list = [] then
           None
        else if List.head list = x then
             Some(acc)
        else if List.tail list = [] then
             Some(-1)
        else 
           recursiveFindNumber (acc + 1) (List.tail list)
    recursiveFindNumber 0 list