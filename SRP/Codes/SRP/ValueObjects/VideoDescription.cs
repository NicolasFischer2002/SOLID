namespace SRP.ValueObjects
{
    internal sealed record VideoDescription
    {
        private const int MaxLength = 200;
        public string Value { get; }

        public VideoDescription(string? value)
        {
            var formattedValue = Format(value);

            Validate(formattedValue);
            Value = formattedValue;
        }

        private static string Format(string? value) => value?.Trim() ?? string.Empty;

        private static void Validate(string value)
        {
            if (value.Length > MaxLength)
                throw new ArgumentException(
                    $"Video description cannot exceed {MaxLength} characters.",
                    nameof(value));
        }

        public override string ToString() => Value;
    }
}