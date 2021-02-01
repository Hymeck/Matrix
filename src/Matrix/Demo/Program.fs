open System
open Library
open MathNet.Numerics.LinearAlgebra

[<EntryPoint>]
let main argv =
    let reversedMatrix =
        matrix [ [ 1.0; 1.0; 0.0 ]
                 [ 0.0; 1.0; 0.0 ]
                 [ 0.0; 0.0; 1.0 ] ]

    let x = vector [ 1.0; 0.0; 1.0 ]
    let i = 3 - 1

    let result = Util.perform reversedMatrix x i
    match result with
    | Some result -> Console.WriteLine(result.ToMatrixString())
    | None -> Console.WriteLine("Матрица А с крышкой не обратима!")
    0