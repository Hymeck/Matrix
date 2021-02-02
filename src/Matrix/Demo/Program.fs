open System
open Library
open MathNet.Numerics.LinearAlgebra

[<EntryPoint>]
let main argv =
    Console.WriteLine("Демо-пример.\n")
    Console.WriteLine("Входные данные:")
    let inversedMatrix =
        matrix [ [ 1.0; 1.0; 0.0 ]
                 [ 0.0; 1.0; 0.0 ]
                 [ 0.0; 0.0; 1.0 ] ]
    Console.WriteLine(" -1\nA   =\n" + inversedMatrix.ToMatrixString())
    
    let x = vector [ 1.0; 0.0; 1.0 ]
    Console.WriteLine("x =\n" + x.ToVectorString())
    
    let i = 2
    Console.WriteLine($"i = {i + 1}.\n")
    
    let result = Util.perform inversedMatrix x i
    match result with
    | Some result -> Console.WriteLine("Итоговая матрица:\n" + result.ToMatrixString())
    | None -> Console.WriteLine("        _-1\nМатрица А   не обратима!")
    0