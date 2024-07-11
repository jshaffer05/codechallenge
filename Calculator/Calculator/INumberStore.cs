namespace Calculator
{
    public interface INumberStore
    {

        void store(int pos1, int pos2);
        void clear(int location);
        int get(int location);


    }
}
