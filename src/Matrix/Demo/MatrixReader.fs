module MatrixReader

open System
open System.IO
open System.Linq
open MathNet.Numerics.LinearAlgebra

let toInt (str: string): int = Convert.ToInt32 str

let toList (str: string): float list =
    let numbers = str.Split ';'
    [ for number in numbers -> Convert.ToDouble number ]

let readFile (fileName: string) =
    let lines = File.ReadAllLines fileName
    let matrixSize = toInt lines.[0]
    let index = toInt lines.[lines.Length - 1] - 1
    let list = toList lines.[lines.Length - 2]
    let matrixLines = (lines.Skip 1).Take(matrixSize)

    let rowList = [ for row in matrixLines -> toList row ]

    (matrix rowList, vector list, index)