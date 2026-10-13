using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal class YouTubeVideo
    {
        public Guid Id { get; }
        public YouTubeVideoTitle Title { get; }
        public YouTubeVideoDescription Description { get; }
        public VideoType Type { get; }
        public Uri Link { get; }

        public YouTubeVideo(
            Guid id, 
            YouTubeVideoTitle title, 
            YouTubeVideoDescription description, 
            VideoType type,
            Uri link)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid video id.", nameof(id));
            }

            if (!Enum.IsDefined(type))
            {
                throw new ArgumentException("Video type invalid.", nameof(type));
            }

            Id = id;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Type = type;
            Link = link ?? throw new ArgumentNullException(nameof(link));
        }
    }
}