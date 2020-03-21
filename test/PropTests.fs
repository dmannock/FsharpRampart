open FsCheck
open FsharpRampart

let creationOrderesLowestFirst (x: int) (y: int) = 
    toInterval(x, y) = toInterval(y, x)
    
Check.Quick creationOrderesLowestFirst

let fromIntervalSameAsReadingLesserAndGreater (x: int) (y: int) = 
    let interval = toInterval(x, y)
    let a = interval |> fromInterval
    let b = (lesser interval, greater interval)
    a = b

Check.Quick fromIntervalSameAsReadingLesserAndGreater

let relationWithIntervalsOrderSwappedAndInverted (x: int) (y: int) (a: int) (b: int) = 
    let interval1 = toInterval(x, y)
    let interval2 = toInterval(a, b)
    let rel1 = relate interval1 interval2
    let rel2 = relate interval2 interval1 |> invert
    rel1 = rel2

Check.Quick relationWithIntervalsOrderSwappedAndInverted

let relateInversedTwiceMatchesOriginal relation =
    let invertedTwice = relation |> invert |> invert
    invertedTwice = relation
    
Check.Quick relateInversedTwiceMatchesOriginal

