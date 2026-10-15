using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal abstract class Playlist
    {
        protected Guid Id { get; }
        protected Guid UserId { get; }
        protected PlaylistName PlaylistName { get; }
        protected CreationDateUTC CreationDateUTC { get; }
        protected PlaylistVisibility Visibility { get; }
        protected Videos Videos { get; }
        protected Uri Link { get; }

        protected Playlist(
            Guid id,
            Guid userId,
            PlaylistName playlistName, 
            CreationDateUTC creationDateUTC,
            PlaylistVisibility visibility,
            Videos videos,
            Uri link)
        {
            if (!Enum.IsDefined(visibility))
            {
                throw new ArgumentException("Invalid playlist visibility.", nameof(visibility));
            }

            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid playlist id.", nameof(id));
            }

            if (userId == Guid.Empty)
            {
                throw new ArgumentException("Invalid user id.", nameof(userId));
            }

            Id = id;
            UserId = userId;
            PlaylistName = playlistName ?? throw new ArgumentNullException(nameof(playlistName));
            CreationDateUTC = creationDateUTC ?? throw new ArgumentNullException(nameof(creationDateUTC));
            Visibility = visibility;
            Videos = videos ?? throw new ArgumentNullException(nameof(videos));
            Link = link ?? throw new ArgumentNullException(nameof(link));
        }

        public abstract void AddVideo(Video video);
    }
}