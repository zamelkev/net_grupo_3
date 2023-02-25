namespace net_grupo_3.Exceptions;

[Serializable]
public class WrongCredentialsException : Exception
{

    public WrongCredentialsException() : base() { }
    public WrongCredentialsException(string message) : base(message) { }
}
