using System;

namespace Containers.Exceptions
{
    public class EmptyListException : Exception
    {
        private string _message;
        public override string Message => _message;

        public EmptyListException() : base()
        {
            _message = "Nie można usunąć elementu z pustej kolekcji.";
        }
    }
}
