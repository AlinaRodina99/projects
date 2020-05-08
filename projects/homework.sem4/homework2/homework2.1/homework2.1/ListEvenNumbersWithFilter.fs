module ListEvenNumbersWithFilter

///<summary> Function to count even number in list with map function   .</summary>
let filterEvenNumber list = list |> List.filter (fun x -> x % 2 = 0) |> List.length