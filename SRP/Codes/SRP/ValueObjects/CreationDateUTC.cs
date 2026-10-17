namespace SRP.ValueObjects
{
    internal sealed record CreationDateUTC
    {
        public DateTime Value { get; }

        public CreationDateUTC(DateTime value)
        {
            Validate(value);
            Value = value;
        }

        private static void Validate(DateTime value)
        {
            if (value.Kind != DateTimeKind.Utc)
                throw new ArgumentException(
                    "Creation date must be in UTC.",
                    nameof(value));
        }

        public override string ToString() => Value.ToString("O");
    }
}