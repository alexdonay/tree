using System;

namespace tree
{
    public class Nodo<T>
    {
        public T Value { get; set; }
        
        public Nodo<T>? Left { get; set; }
        
        public Nodo<T>? Right { get; set; }

        public Nodo(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value}";
        }

        public bool Greater<T>(Nodo<T> value) => ((IComparable<T>)this.Value).CompareTo(value.Value) > 0;

        public bool Equals<T>(Nodo<T> other)
        {
            return ((IComparable<T>)this.Value).CompareTo(other.Value) ==0;
        }
    }
}
