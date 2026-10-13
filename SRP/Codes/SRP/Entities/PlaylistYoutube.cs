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
            YouTubeVideos videos)
            : base(id, userId, playlistName, creationDateUTC, visibility, videos)
        {

        }

        public override void AddVideo(YouTubeVideo video)
        {
            throw new NotImplementedException();
        }
    }
}