using SRP.Collections;
using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal class PlaylistYoutubeMusic : Playlist
    {
        public PlaylistYoutubeMusic(
            Guid id,
            Guid userId,
            PlaylistName playlistName,
            CreationDateUTC creationDateUTC,
            PlaylistVisibility visibility,
            Videos videos,
            Uri link)
            : base(id, userId, playlistName, creationDateUTC, visibility, videos, link)
        {
            if (Videos.Any(video => video.Type != VideoType.Music))
                throw new ArgumentException(
                    "Only music videos can be added to a YouTube Music playlist.",
                    nameof(videos));
        }

        public override void AddVideo(Video video)
        {
            ArgumentNullException.ThrowIfNull(video, nameof(video));

            if (video.Type != VideoType.Music)
                throw new ArgumentException(
                    "Only music videos can be added to a YouTube Music playlist.",
                    nameof(video));

            AddVideoToCollection(video);
        }
    }
}