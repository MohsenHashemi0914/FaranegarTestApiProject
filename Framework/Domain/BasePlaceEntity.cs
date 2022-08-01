namespace Framework.Domain
{
    public class BasePlaceEntity<TKey> : BaseEntity<TKey>
    {
        public string Name { get; protected set; }
        public string Position { get; protected set; }
        public ushort Scope { get; protected set; }

        public BasePlaceEntity(string name, string position, ushort scope)
        {
            Name = name;
            Position = position;
            Scope = scope;
        }
    }
}
