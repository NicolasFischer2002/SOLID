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