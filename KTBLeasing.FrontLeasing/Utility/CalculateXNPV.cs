using System;
using System.Linq;
using Money = System.Decimal;
using Rate = System.Double;
using System.Collections.Generic;
public struct Pair<T, Z>
{

    public Pair(T first, Z second) { First = first; Second = second; }

    public readonly T First;

    public readonly Z Second;

}


public class CashFlow
{

    public CashFlow(Money amount, DateTime date) { Amount = amount; Date = date; }

    public readonly Money Amount;
    public readonly DateTime Date;
}

public struct AlgorithmResult<TKindOfResult, TValue>
{

    public AlgorithmResult(TKindOfResult kind, TValue value)
    {

        Kind = kind;
        Value = value;
    }

    public readonly TKindOfResult Kind;
    public readonly TValue Value;
}

public enum ApproximateResultKind
{
    ApproximateSolution,
    ExactSolution,
    NoSolutionWithinTolerance
}

public static class Algorithms
{

    internal static Money CalculateXNPV(IEnumerable<CashFlow> cfs, Rate r)
    {

        if (r <= -1)
            r = -0.99999999; // Very funky ... Better check what an IRR <= -100% means

        return (from cf in cfs
                let startDate = cfs.OrderBy(cf1 => cf1.Date).First().Date
                select cf.Amount / (decimal)Math.Pow(1 + r, (cf.Date - startDate).Days / 365.0)).Sum();
    }

    internal static Pair<Rate, Rate> FindBrackets(Func<IEnumerable<CashFlow>, Rate, Money> func, IEnumerable<CashFlow> cfs)
    {

        // Abracadabra magic numbers ...
        const int maxIter = 100;
        const Rate bracketStep = 0.5;
        const Rate guess = 0.1;

        Rate leftBracket = guess - bracketStep;
        Rate rightBracket = guess + bracketStep;
        var iter = 0;

        while (func(cfs, leftBracket) * func(cfs, rightBracket) > 0 && iter++ < maxIter)
        {

            leftBracket -= bracketStep;
            rightBracket += bracketStep;
        }

        if (iter >= maxIter)
            return new Pair<double, double>(0, 0);

        return new Pair<Rate, Rate>(leftBracket, rightBracket);
    }

    // From "Applied Numerical Analyis" by Gerald
    internal static AlgorithmResult<ApproximateResultKind, Rate> Bisection(Func<Rate, Money> func, Pair<Rate, Rate> brackets, Rate tol, int maxIters)
    {

        int iter = 1;

        Money f3 = 0;
        Rate x3 = 0;
        Rate x1 = brackets.First;
        Rate x2 = brackets.Second;

        do
        {
            var f1 = func(x1);
            var f2 = func(x2);

            if (f1 == 0 && f2 == 0)
                return new AlgorithmResult<ApproximateResultKind, Rate>(ApproximateResultKind.NoSolutionWithinTolerance, x1);

            if (f1 * f2 > 0)
                throw new ArgumentException("x1 x2 values don't bracket a root");

            x3 = (x1 + x2) / 2;
            f3 = func(x3);

            if (f3 * f1 < 0)
                x2 = x3;
            else
                x1 = x3;

            iter++;

        } while (Math.Abs(x1 - x2) / 2 > tol && f3 != 0 && iter < maxIters);

        if (f3 == 0)
            return new AlgorithmResult<ApproximateResultKind, Rate>(ApproximateResultKind.ExactSolution, x3);

        if (Math.Abs(x1 - x2) / 2 < tol)
            return new AlgorithmResult<ApproximateResultKind, Rate>(ApproximateResultKind.ApproximateSolution, x3);

        if (iter > maxIters)
            return new AlgorithmResult<ApproximateResultKind, Rate>(ApproximateResultKind.NoSolutionWithinTolerance, x3);

        throw new Exception("It should never get here");
    }

    public static AlgorithmResult<ApproximateResultKind, Rate> CalculateXIRR(IEnumerable<CashFlow> cfs, Rate tolerance, int maxIters)
    {

        var brackets = FindBrackets(CalculateXNPV, cfs);

        if (brackets.First == brackets.Second)
            return new AlgorithmResult<ApproximateResultKind, double>(ApproximateResultKind.NoSolutionWithinTolerance, brackets.First);

        return Bisection(r => CalculateXNPV(cfs, r), brackets, tolerance, maxIters);
    }
}