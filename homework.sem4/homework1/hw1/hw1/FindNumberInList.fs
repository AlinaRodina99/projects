module FindNumberInList

///<summary> Function finds certain number in list.</summary>
let findNumber x list =
    let rec recursiveFindNumber acc list =
        match list with
        | [] -> None
        | _ when List.head list = x -> Some(acc)
        | _ when List.tail list = [] -> Some(-1)
        | _ -> recursiveFindNumber (acc + 1) (List.tail list)
    recursiveFindNumber 0 list