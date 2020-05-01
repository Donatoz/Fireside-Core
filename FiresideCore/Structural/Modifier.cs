namespace FiresideCore.Structural
{
    public struct Modifier
    {
        public string Id;
        public int Value;

        public Modifier(int value, string id = "modifier")
        {
            Value = value;
            Id = id;
        }
    }
}