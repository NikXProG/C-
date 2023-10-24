namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int periodStart = -1, periodLength = 0;
            for (int j = 1; j <= resultFrac.Length / 2; j++)
            {
                bool isPeriodic = true;
                for (int l = 0; l < resultFrac.Length / 2; l++)
                {
                    if (resultFrac[l] == resultFrac[l + j])
                    {
                        for (int n = j; n < resultFrac.Length; n++)
                        {
                            if (resultFrac[n] != resultFrac[n - j])
                            {
                                isPeriodic = false;
                                break;
                            }
                        }

                        if (isPeriodic == true)
                        {
                            periodStart = l;
                            periodLength = j;
                            break;
                        }
                    }

                }
                if (periodStart >= 0)
                {
                    resultFrac = resultFrac.Substring(0, periodStart) + "(" + resultFrac.Substring(periodStart, periodLength) + ")";
                }
            }
        }
    }
}
