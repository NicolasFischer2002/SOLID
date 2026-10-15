namespace SRP.ValueObjects
{
    internal sealed record VideoDescription
    {
        public string Value { get; }
        private const int MaxLength = 200;

        public VideoDescription(string value)
        {
            var formattedValue = Format(value);
            Validate(formattedValue);

            Value = formattedValue;
        }

        private static string Format(string? value) => value?.Trim() ?? string.Empty;

        private static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "YouTube video description cannot be null or whitespace.",
                    nameof(value));
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException(
                    $"YouTube video description cannot exceed {MaxLength} characters.",
                    nameof(value));
            }
        }

        public override string ToString() => Value;
    }
}