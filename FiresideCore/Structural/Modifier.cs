namespace FiresideCore.Structural
{
    /// <summary>
    /// Represents value container.
    /// </summary>
    public struct Modifier
    {
        /// <summary>
        /// Modifier id.
        /// </summary>
        public readonly string Id;
        
        /// <summary>
        /// Modifier value.
        /// </summary>
        public readonly int Value;

        public Modifier(int value, string id = "modifier")
        {
            Value = value;
            Id = id;
        }
    }
}