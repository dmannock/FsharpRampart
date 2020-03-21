module PropTests

open System
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

let relationWithIntervalsOrderSwappedAndInverted<'T when 'T : comparison> (x: 'T, y: 'T) (a: 'T, b: 'T) =
    let interval1 = toInterval(x, y)
    let interval2 = toInterval(a, b)
    let rel1 = relate interval1 interval2
    let rel2 = relate interval2 interval1 |> invert
    rel1 = rel2

Check.Quick relationWithIntervalsOrderSwappedAndInverted<Boolean>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Byte>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Char>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<DateTime>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<DateTimeOffset>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Decimal>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<NormalFloat>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Guid>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Int16>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Int32>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Int64>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<SByte>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<String>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<TimeSpan>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<UInt16>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<UInt32>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<UInt64>
Check.Quick relationWithIntervalsOrderSwappedAndInverted<Numerics.BigInteger>

let relateInversedTwiceMatchesOriginal relation =
    let invertedTwice = relation |> invert |> invert
    invertedTwice = relation
    
Check.Quick relateInversedTwiceMatchesOriginal