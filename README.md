# FsharpRampart
F# port of the [Haskell Rampart library](https://github.com/tfausak/rampart) by [Taylor Fausak](https://taylor.fausak.me/2020/03/13/relate-intervals-with-rampart/). 

## Examples

```
open FsharpRampart
relate (toInterval (2, 4)) (toInterval (3, 5))
```
Output: Overlaps

```
let dt1 = (DateTime(2020,01,01), DateTime(2020,03,14)) |> toInterval
let dt2 = (DateTime(2019,01,01), DateTime(2020,03,14)) |> toInterval
relate dt1 dt2
```
Output: Finishes

```
invert Before
```
Output: After