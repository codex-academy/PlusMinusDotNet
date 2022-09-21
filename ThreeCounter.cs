namespace PlusMinus;


public class ThreeCounter : ICounter {

    public ThreeCounter() {
        Max = 30;
    }


    public void Plus() {
        if (Value < Max) {
            Value += 3;
        }
    }

    public void Minus() {
        if (Value > 0) {
            Value -= 3;
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