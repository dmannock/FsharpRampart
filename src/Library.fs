namespace FsharpRampart

type Relation =
    | Before
    | Meets
    | Overlaps
    | FinishedBy
    | Contains
    | Starts
    | Equal
    | StartedBy
    | During
    | Finishes
    | OverlappedBy
    | MetBy
    | After
    
[<AutoOpen>]
module Interval =
    type Interval<'a> = private Interval of 'a * 'a

    let toInterval (x, y) = if x > y then Interval (y, x) else Interval (x, y)

    let fromInterval (Interval(x, y)) = x, y

    let lesser (Interval(x, _)) = x

    let greater (Interval(_, y)) = y

    type private ComparisonResult = | LT | EQ | GT
    let private compare x y = 
        if x < y then LT
        else if x = y then EQ
        else GT

    let relate x y = 
        let lxly = compare (lesser x) (lesser y)
        let lxgy = compare (lesser x) (greater y)
        let gxly = compare (greater x) (lesser y)
        let gxgy = compare (greater x) (greater y)
        match (lxly, lxgy, gxly, gxgy) with
        | (EQ, _, _, EQ) -> Equal
        | (_, _, LT, _) -> Before
        | (_, _, EQ, _) -> Meets
        | (_, EQ, _, _) -> MetBy
        | (_, GT, _, _) -> After
        | (LT, _, _, LT) -> Overlaps
        | (LT, _, _, EQ) -> FinishedBy
        | (LT, _, _, GT) -> Contains
        | (EQ, _, _, LT) -> Starts
        | (EQ, _, _, GT) -> StartedBy
        | (GT, _, _, LT) -> During
        | (GT, _, _, EQ) -> Finishes
        | (GT, _, _, GT) -> OverlappedBy

    let invert = function
        | After -> Before
        | Before -> After
        | Contains -> During
        | During -> Contains
        | Equal -> Equal
        | FinishedBy -> Finishes
        | Finishes -> FinishedBy
        | Meets -> MetBy
        | MetBy -> Meets
        | OverlappedBy -> Overlaps
        | Overlaps -> OverlappedBy
        | StartedBy -> Starts
        | Starts -> StartedBy
