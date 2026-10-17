using SRP.Collections;
using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal abstract class Playlist
    {
        private readonly Videos _videos;

        protected Guid Id { get; }
        protected Guid UserId { get; }
        protected PlaylistName PlaylistName { get; }
        protected CreationDateUTC CreationDateUTC { get; }
        protected PlaylistVisibility Visibility { get; }
        protected Uri Link { get; }

        public IReadOnlyList<Video> Videos => _videos.GetVideos();

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
                throw new ArgumentException("Invalid playlist visibility.", nameof(visibility));

            if (id == Guid.Empty)
                throw new ArgumentException("Invalid playlist id.", nameof(id));

            if (userId == Guid.Empty)
                throw new ArgumentException("Invalid user id.", nameof(userId));

            ArgumentNullException.ThrowIfNull(playlistName, nameof(playlistName));
            ArgumentNullException.ThrowIfNull(creationDateUTC, nameof(creationDateUTC));
            ArgumentNullException.ThrowIfNull(link, nameof(link));

            PlaylistName = playlistName;
            CreationDateUTC = creationDateUTC;
            Link = link;

            ArgumentNullException.ThrowIfNull(videos, nameof(videos));

            Id = id;
            UserId = userId;
            Visibility = visibility;
            _videos = new Videos(videos.GetVideos());
        }

        public abstract void AddVideo(Video video);

        protected void AddVideoToCollection(Video video)
        {
            _videos.Add(video);
        }

        public bool RemoveVideo(Guid videoId)
        {
            return _videos.Remove(videoId);
        }
    }
}