# FsharpRampart
F# port of the [Haskell Rampart library](https://github.com/tfausak/rampart) by [Taylor Fausak](https://taylor.fausak.me/2020/03/13/relate-intervals-with-rampart/). 

## Examples

```csharp
open FsharpRampart
relate (toInterval (2, 4)) (toInterval (3, 5))
// Output: Overlaps
```

```csharp
let dt1 = (DateTime(2020,01,01), DateTime(2020,03,14)) |> toInterval
let dt2 = (DateTime(2019,01,01), DateTime(2020,03,14)) |> toInterval
relate dt1 dt2
//Output: Finishes
```

```csharp
invert Before
//Output: After
```

## C# interop
Usage is similar but to make it easier to consume using directives will be needed depending on which module the function is in.
```csharp
using FsharpRampart;
using static FsharpRampart.Interval;

relate(toInterval(2, 4), toInterval(3, 5));
//Output: Overlaps

var dt1 = toInterval(new DateTime(2020,01,01), new DateTime(2020,03,14));
var dt2 = toInterval(new DateTime(2019,01,01), new DateTime(2020,03,14));
relate(dt1, dt2);
//Output: Finishes

invert(Relation.Before);
//Output: After
```
