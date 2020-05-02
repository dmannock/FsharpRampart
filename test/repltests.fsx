#r "../src/bin/Debug/netstandard2.0/FsharpRampart.dll"
open System
open FsharpRampart

let equalityTest() =
    After = After
    // true

    let a = (1, 2)|> toInterval
    let b = (1, 2)|> toInterval
    a = b
    // true

let test() =
    relate (toInterval (2, 4)) (toInterval (3, 5))
    // Relation = Overlaps

    let dt1 = (DateTime(2020,01,01), DateTime(2020,03,14)) |> toInterval
    let dt2 = (DateTime(2019,01,01), DateTime(2020,03,14)) |> toInterval
    relate dt1 dt2
    // Relation = Finishes

    invert Before
    // Relation = After