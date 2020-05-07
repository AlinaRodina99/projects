module ListOfDegreesOfTwo

///<summary> Function to make the list of powers of two based on values of n and m, the list will look like this: [2^n; 2^(n+1); ... ; 2^(n+m)].</summary>
let listOfDegreesOfTwo n m =
    
    let powOfTwo n =
        let rec recursivePowOfTwo acc i =
            match n with 
            | 0 -> 1
            | _ when i = n + 1 -> acc
            | _ -> recursivePowOfTwo (acc * 2) (i + 1)
        recursivePowOfTwo 1 1 

    let rec recursiveListOfDegreesOfTwo n m i newList =
        if i = n - 1 then
            Some(newList)
        else 
            recursiveListOfDegreesOfTwo n m (i - 1) (newList.Head / 2 :: newList)

    if (n < 0) || (m < 0) then
        None
    else 
        recursiveListOfDegreesOfTwo n m (n + m) [powOfTwo (n + m)]



