namespace FiresideCore.Structural.Zones
{
    public interface IZoneAdapter<in T>
    {
        void Add(T item);
        void Remove(T item);
    }
}