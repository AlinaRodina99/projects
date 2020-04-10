module ReverseList

///function to reverse list
let reverseList list =
    let rec recursiveReverseList list newList =
        match list with 
        | _ when list = [] -> Some(newList)
        | _ -> recursiveReverseList (List.tail list) ((List.head list) :: newList)
    recursiveReverseList list []
