module ReverseList

///<summary> Function to reverse list.</summary>
let reverseList list =
    let rec recursiveReverseList list newList =
        match list with 
        | [] -> Some(newList)
        | hd :: tl -> recursiveReverseList tl (hd :: newList)
    recursiveReverseList list []
