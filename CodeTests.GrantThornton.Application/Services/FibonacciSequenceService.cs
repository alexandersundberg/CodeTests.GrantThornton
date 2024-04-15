namespace CodeTests.GrantThornton.Application.Services
{
    public class FibonacciSequenceService
    {
        public int GetFibonacciNumber(int n)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 1);
            if (n == 1)
                return 0;

            var (first, second, sum) = (0, 1, 1);
            foreach (var i in Enumerable.Range(1, n - 2))
            {
                sum = first + second;
                first = second;
                second = sum;
            }

            return sum;
        }
    }
}
