using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal class Video
    {
        public Guid Id { get; }
        public VideoTitle Title { get; }
        public VideoDescription Description { get; }
        public VideoType Type { get; }
        public Uri Link { get; }

        public Video(
            Guid id,
            VideoTitle title,
            VideoDescription description,
            VideoType type,
            Uri link)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid video id.", nameof(id));

            if (!Enum.IsDefined(type))
                throw new ArgumentException("Invalid video type.", nameof(type));

            ArgumentNullException.ThrowIfNull(title, nameof(title));
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            ArgumentNullException.ThrowIfNull(link, nameof(link));

            ValidateLink(link);

            Id = id;
            Title = title;
            Description = description;
            Type = type;
            Link = link;
        }

        private static void ValidateLink(Uri link)
        {
            if (!link.IsAbsoluteUri)
                throw new ArgumentException("Video link must be an absolute URI.", nameof(link));

            if (link.Scheme != Uri.UriSchemeHttp &&
                link.Scheme != Uri.UriSchemeHttps)
            {
                throw new ArgumentException(
                    "Video link must use HTTP or HTTPS.",
                    nameof(link));
            }
        }
    }
}