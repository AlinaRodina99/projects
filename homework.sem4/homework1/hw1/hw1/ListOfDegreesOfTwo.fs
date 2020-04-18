module ListOfDegreesOfTwo

///function to get list like this [2^n; 2^n+1; ...;2^n+m]
let listOfDegreesOfTwo n m =
    
    ///auxiliary function of raising two to a power
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



