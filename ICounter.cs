namespace PlusMinus;


public interface ICounter{

    void Plus();
    void Minus();

    void Clear();

    public int Value {
        get;
    }

    public int Max {
        get;
        set;
    }

}