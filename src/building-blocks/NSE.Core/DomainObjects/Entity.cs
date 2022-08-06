using NSE.Core.Messages;

namespace NSE.Core.DomainObjects
{
    public abstract class Entity
    {
        private List<Event> _notificacoes;

        public Guid Id { get; set; }

        public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

        // Comparações
        public bool IsTransient() => Id == default;

        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Entity)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item.Id.Equals(Id);
        }

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return (Equals(right, null));
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right) => !(left == right);

        // Eventos
        public void AdicionarEvento(Event evento)
        {
            _notificacoes ??= new List<Event>();
            _notificacoes.Add(evento);
        }

        public void RemoverEvento(Event evento) => _notificacoes?.Remove(evento);

        public void LimparEventos() => _notificacoes?.Clear();
    }
}
