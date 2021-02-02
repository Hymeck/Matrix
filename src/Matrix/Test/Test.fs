module Test

open Library
open NUnit.Framework
open MathNet.Numerics.LinearAlgebra

[<SetUp>]
let Setup () = ()

[<Test>]
let Matrix2D_WithIthZeroElement () =
    let matrix2d = matrix [ [ 3.0; 1.0 ]; [ 2.0; 0.0 ] ]
    let x = vector [ 0.0; 1.0 ]
    let i = 2 - 1

    let result = Util.perform matrix2d x i
    Assert.AreEqual(true, result.IsNone)
