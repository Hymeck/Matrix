open System
open Library
open MathNet.Numerics.LinearAlgebra

[<EntryPoint>]
let main argv =
    let reversedMatrix = matrix [[1.0; 1.0; 0.0]
                                 [0.0; 1.0; 0.0]
                                 [0.0; 0.0; 1.0]]
    let x = vector [1.0; 0.0; 1.0]
    let i = 3 - 1
    let l = Util.multiplyByVector (reversedMatrix, x) // 1.
    let check = Util.check (l, i)
    let result =
        if check.IsSome
        then
            let wavedL = Util.setMinusOneAt (x, i) // 2
            let cuppedL = Util.multiply (l.At i) wavedL // 3
            let almostE = Util.almostIdentityMatrix i cuppedL // 4
            let result = Util.finalMultiply almostE reversedMatrix // 5
            result.ToMatrixString()
        else "Матрица А с крышкой не обратима!"
    Console.WriteLine(result)
    0