﻿using IDoubleLinkedList;
using System;

namespace ElementNotFoundException
{
    public class ElementNotFoundException<TValue> : Exception
    {
        private const string expectedMessageValue = "Nie znaleziono elementu o wartości '{0}' w kolekcji. ";
        private const string expectedMessageList = "Kolekcja zawiera: {0}. ";

        public ElementNotFoundException() { }

        public ElementNotFoundException(TValue value)
        {
            throw new Exception(string.Format(expectedMessageValue, value));
        }

        public ElementNotFoundException(TValue value, IDoubleLinkedList<TValue> list)
        {
            var msgValue = string.Format(expectedMessageValue, value);
            var msgList = string.Format(expectedMessageList, );

            throw new Exception(msgValue + msgList);
        }
    }
}