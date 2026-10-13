using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal class PlaylistYoutubeMusic : Playlist
    {
        public PlaylistYoutubeMusic(
            PlaylistName playlistName,
            CreationDateUTC creationDateUTC,
            PlaylistVisibility visibility) 
            : base(playlistName, creationDateUTC, visibility)
        {

        }
    }
}