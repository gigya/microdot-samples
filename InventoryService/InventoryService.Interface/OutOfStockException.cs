using Gigya.Common.Contracts.Exceptions;
using System;
using System.Runtime.Serialization;

namespace InventoryService.Interface
{
    [Serializable]
    public class OutOfStockException : RequestException
    {
        public OutOfStockException(string message) : base(message) { }
        protected OutOfStockException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
