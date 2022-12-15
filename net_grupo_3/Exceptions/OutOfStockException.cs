namespace net_grupo_3.Exceptions;

[Serializable]
public class OutOfStockException : Exception
{

    public OutOfStockException() : base() { }
    public OutOfStockException(string message) : base(message) { }
}
