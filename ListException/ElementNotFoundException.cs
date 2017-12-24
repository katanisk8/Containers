using System;
using System.Runtime.Serialization;


public class ElementNotFoundException<TValue> : Exception
{
    private const string expectedMessage = "Nie znaleziono elementu o wartości '{0}' w kolekcji.";

    public ElementNotFoundException() { }

    public ElementNotFoundException(string message) : base(expectedMessage) { }

    public ElementNotFoundException(string message, Exception innerException) : base(expectedMessage, innerException) { }

    protected ElementNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }


    public ElementNotFoundException(TValue value)
    {
        throw new Exception(string.Format(expectedMessage, value));
    }

}
