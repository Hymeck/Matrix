namespace Library

open MathNet.Numerics.LinearAlgebra

module Util =
    let private minusOne = -1

    let private check (x: Vector<double>, i: int): bool = x.At i = double 0

    let private setMinusOneAt (i: int) (x: Vector<double>) =
        let newX = x.Clone()
        newX.At(i, double minusOne)
        newX

    let inline private multiply (multiplier: double) (x: Vector<double>) = ((-1.0) / multiplier) * x

    let private almostIdentityMatrix (column: int) (x: Vector<double>) =
        let mutable identityMatrix =
            Matrix<double>.Build.Dense(x.Count, x.Count)

        (DiagonalMatrix.identity<double> x.Count)
            .CopyTo(identityMatrix)

        identityMatrix.SetColumn(column, x)
        identityMatrix

    // todo: perform more efficient (O(n^3) -> O(n^2))
    let private matrixProduct q a = q * a

    let perform (matrix: Matrix<double>) (vector: Vector<double>) (index: int): Option<Matrix<double>> =
        let l = matrix * vector // 1.

        if check (l, index) then
            None
        else
            let q =
                l
                |> setMinusOneAt index // 2.
                |> multiply (l.At index) // 3.
                |> almostIdentityMatrix index // 4.

            Some(matrixProduct q matrix) // 5.