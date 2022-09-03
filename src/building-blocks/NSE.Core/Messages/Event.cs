using MediatR;

namespace NSE.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; protected set; }

        protected Event() => TimeStamp = DateTime.Now;
    }
}