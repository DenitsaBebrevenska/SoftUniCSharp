namespace CustomComparator
{
    public class CustomNumberComparator: IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            return x > y ? 1 : -1;
        }
    }
}
