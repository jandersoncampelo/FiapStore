using System.Runtime.Serialization;

namespace FiapStore.Application.Exceptions
{
    [Serializable]
    internal class EntityNotFoundException : Exception
    {
        private Type type;
        private long id;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }

        public EntityNotFoundException(Type type, long id)
        {
            this.type = type;
            this.id = id;
        }

        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}