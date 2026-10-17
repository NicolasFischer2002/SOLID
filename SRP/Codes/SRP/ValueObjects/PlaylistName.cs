
namespace SRP.ValueObjects
{
    internal sealed record PlaylistName
    {
        private const int MaxLength = 50;
        private const string InvalidCharacters = "@&\"'";

        public string Value { get; }

        public PlaylistName(string? value)
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
                throw new ArgumentException("Playlist name cannot be null or empty.", nameof(value));
            }

            ValidateLength(value);
            ValidateInvalidCharacters(value);
        }

        private static void ValidateLength(string value)
        {
            if (value.Length > MaxLength)
            {
                throw new ArgumentException(
                    $"Playlist name cannot exceed {MaxLength} characters.",
                    nameof(value));
            }
        }

        private static void ValidateInvalidCharacters(string value)
        {
            foreach (var invalidChar in InvalidCharacters)
            {
                if (value.Contains(invalidChar))
                {
                    throw new ArgumentException(
                        $"Playlist name cannot contain the character '{invalidChar}'.",
                        nameof(value));
                }
            }
        }

        public override string ToString() => Value;
    }
}