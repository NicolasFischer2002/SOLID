
namespace SRP.ValueObjects
{
    internal sealed record VideoTitle
    {
        private const int MaxLength = 100;

        public string Value { get; }

        public VideoTitle(string? value)
        {
            var formattedValue = Format(value);

            Validate(formattedValue);
            Value = formattedValue;
        }

        private static string Format(string? value) => value?.Trim() ?? string.Empty;

        private static void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(
                    "Video title cannot be null or whitespace.",
                    nameof(value));

            if (value.Length > MaxLength)
                throw new ArgumentException(
                    $"Video title cannot exceed {MaxLength} characters.",
                    nameof(value));
        }

        public override string ToString() => Value;
    }
}