namespace PlusMinus;


public class Counter : ICounter {

    public Counter() {
        Max = 10;
    }


    public void Plus() {
        if (Value < Max) {
            Value++;
        }
    }

    public void Minus() {
        if (Value > 0) {
            Value--;
        }
    }

    public void Clear(){
        Value = 0;
    }

    public int Value {
        get;
        private set;
    }

    public int Max {
        get;set;
    }

}