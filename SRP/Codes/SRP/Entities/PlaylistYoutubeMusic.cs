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

        }

        public override void AddVideo(Video video)
        {
            if (video.Type != VideoType.Music)
                throw new ArgumentException(
                    "Only music videos can be added to a YouTube Music playlist.", 
                    nameof(video));

            Videos.Add(video);
        }
    }
}