namespace Calculator
{
    public class NumberStore : INumberStore
    {
        int pos1 = 0;
        int pos2 = 0;
        public void clear(int location)
        {
            if (location == 1)
            {
                pos1 = 0;
            }
            else
            {
                pos2 = 0;
            }
        }

        public int get(int location)
        {
            if (location == 1)
            {
                return pos1;
            }
            else
            {
                return pos2;
            }
        }

        public void store(int location, int number)
        {
            if (location == 1)
            {
                this.pos1 = number;
            }
            else
            {
                this.pos2 = number;
            }
        }

    }
}
