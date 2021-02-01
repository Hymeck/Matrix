namespace Library

open MathNet.Numerics.LinearAlgebra

module Util =
    let private minusOne = -1

    let private check (x: Vector<double>, i: int) =
        if x.At i = double 0 then None else Some(x)

    let private setMinusOneAt (i: int) (x: Vector<double>) =
        let newX = x.Clone()
        newX.At(i, double minusOne)
        newX

    let private multiply (multiplier: double) (x: Vector<double>) = (double (-1) / multiplier) * x

    let private almostIdentityMatrix (column: int) (x: Vector<double>) =
        let mutable identityMatrix =
            Matrix<double>.Build.Dense(x.Count, x.Count)

        (DiagonalMatrix.identity<double> x.Count)
            .CopyTo(identityMatrix)

        identityMatrix.SetColumn(column, x)
        identityMatrix

    let perform (A: Matrix<double>) (x: Vector<double>) (i: int): Option<Matrix<double>> =
        //todo: check size corresponding
        let l = A * x // 1.
        let check = check (l, i)

        match check with
        | None -> None
        | Some l ->
            let q =
                x
                |> setMinusOneAt i // 2.
                |> multiply (l.At i) // 3.
                |> almostIdentityMatrix i // 4.

            Some(q * A) // 5.