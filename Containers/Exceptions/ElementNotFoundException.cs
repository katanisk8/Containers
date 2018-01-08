using System;
using Containers.DoubleLinkedList;

namespace Containers.Exceptions
{
    public class ElementNotFoundException<TValue> : Exception
    {
        private const string expectedMessageValue = "Nie znaleziono elementu o wartości '{0}' w kolekcji. ";
        private string expectedMessageList = "Kolekcja zawiera: ";

        private string _message;
        public override string Message => _message;

        public ElementNotFoundException() { }

        public ElementNotFoundException(TValue value) : base()
        {
            _message = string.Format(expectedMessageValue, value);
        }

        public ElementNotFoundException(TValue value, IDoubleLinkedList<TValue> list)
        {
            var msgValue = string.Format(expectedMessageValue, value);

            foreach (var item in list)
            {
                expectedMessageList += item.ToString();
            }

            _message = msgValue + expectedMessageList;
        }
    }
}
