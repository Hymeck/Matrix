namespace Library

open MathNet.Numerics.LinearAlgebra

module Util =
    let minusOne = -1
    // 1.
    let multiplyByVector (A: Matrix<double>, x: Vector<double>) =
        A * x
    
    // 2.0
    let check (x: Vector<double>, i: int) =
        if x.At i = double 0 then None else Some(x)
    
    // 2.1
    let setMinusOneAt (x: Vector<double>, i: int) =
        let newX = x.Clone()
        newX.At (i, -1.0)
        newX
    
    // 3.
    let multiply (multiplier: double) (x: Vector<double>) =
        (double (-1) / multiplier) * x
    
    // 4.
    let almostIdentityMatrix (column: int) (x:Vector<double>) =
        let mutable identityMatrix = Matrix<double>.Build.Dense(x.Count, x.Count)
        (DiagonalMatrix.identity<double> x.Count).CopyTo(identityMatrix)
        identityMatrix.SetColumn (column, x)
        identityMatrix
    
    // 5.
    let finalMultiply (Q: Matrix<double>) (A: Matrix<double>)=
        Q * A