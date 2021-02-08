module Demo

open System
open Library
open MathNet.Numerics.LinearAlgebra
open MatrixReader

let printResult (result: Option<Matrix<double>>) =
    match result with
    | Some result -> Console.WriteLine("Итоговая матрица:\n" + result.ToMatrixString())
    | None -> Console.WriteLine("        _-1\nМатрица А   не обратима!")

let printData (matrix: Matrix<double>) (vector: Vector<double>) (index: int) =
    Console.WriteLine("Входные данные:")
    Console.WriteLine(" -1\nA   =\n" + matrix.ToMatrixString())
    Console.WriteLine("x =\n" + vector.ToVectorString())
    Console.WriteLine($"i = {index + 1}.\n")

let demo =
    Console.WriteLine("Демо-пример.\n")
    Console.WriteLine("Входные данные:")

    let inversedMatrix =
        matrix [ [ 1.0; 1.0; 0.0 ]
                 [ 0.0; 1.0; 0.0 ]
                 [ 0.0; 0.0; 1.0 ] ]

    let x = vector [ 1.0; 0.0; 1.0 ]
    let i = 2
    printData inversedMatrix x i
    let result = Util.perform inversedMatrix x i
    printResult result

let withFile (fileName: string) =
    let (matrix, vector, index) = readFile fileName
    printData matrix vector index
    let result = Util.perform matrix vector index
    printResult result

[<EntryPoint>]
let main argv =
    if argv.Length <> 0 then withFile argv.[0] else demo
    0