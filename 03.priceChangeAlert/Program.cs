using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double threshold = double.Parse(Console.ReadLine());
        double lastPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double nextPrice = double.Parse(Console.ReadLine());
            double differenceLastPrice = GetDifferenceLastPrice(lastPrice, nextPrice);
            bool isSignificantDifference = GetDifference(differenceLastPrice, threshold);
            
            string message = GetFinalMessage(nextPrice, lastPrice, differenceLastPrice, isSignificantDifference);
            Console.WriteLine(message);

            lastPrice = nextPrice;
        }
    }

    private static string GetFinalMessage(double nextPrice, double lastPrice, double differenceLastPrice, bool etherTrueOrFalse)
    {
        string to = "";
        if (differenceLastPrice == 0)
        {
            to = string.Format("NO CHANGE: {0}", nextPrice);
        }
        else if (!etherTrueOrFalse)
        {
            to = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, nextPrice, differenceLastPrice);
        }
        else if (etherTrueOrFalse && (differenceLastPrice > 0))
        {
            to = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, nextPrice, differenceLastPrice);
        }
        else if (etherTrueOrFalse && (differenceLastPrice < 0))
            to = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, nextPrice, differenceLastPrice);
        return to;
    }
    private static bool GetDifference(double differenceLastPrice, double threshold)
    {
        if (Math.Abs(differenceLastPrice) >= threshold*100)
        {
            return true;
        }
        return false;
    }

    private static double GetDifferenceLastPrice(double lastPrice, double nextPrice)
    {
        double r = ((nextPrice - lastPrice) / lastPrice)*100;
        return r;
    }
}
