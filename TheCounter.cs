namespace PlusMinus;


public class TheCounter : ICounter
{
    public int Value {
        get {
            return 19;
        }
    }

    public int Max {
        get;set;
     }

    public void Clear()
    {
        // throw new NotImplementedException();
    }

    public void Minus()
    {
        // throw new NotImplementedException();
    }

    public void Plus()
    {
        // throw new NotImplementedException();
    }
}