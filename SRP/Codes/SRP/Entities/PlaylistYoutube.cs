using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal class PlaylistYoutube : Playlist
    {
        public PlaylistYoutube(
            PlaylistName playlistName, 
            CreationDateUTC creationDateUTC, 
            PlaylistVisibility visibility)
            : base(playlistName, creationDateUTC, visibility)
        {

        }
    }
}