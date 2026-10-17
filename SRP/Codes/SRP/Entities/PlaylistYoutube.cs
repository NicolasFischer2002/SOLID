using SRP.Collections;
using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal class PlaylistYoutube : Playlist
    {
        public PlaylistYoutube(
            Guid id,
            Guid userId,
            PlaylistName playlistName,
            CreationDateUTC creationDateUTC,
            PlaylistVisibility visibility,
            Videos videos,
            Uri link)
            : base(id, userId, playlistName, creationDateUTC, visibility, videos, link)
        {

        }

        public override void AddVideo(Video video)
        {
            ArgumentNullException.ThrowIfNull(video, nameof(video));

            AddVideoToCollection(video);
        }
    }
}