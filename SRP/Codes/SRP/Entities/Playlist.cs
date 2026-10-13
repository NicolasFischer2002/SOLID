using SRP.Constants;
using SRP.ValueObjects;

namespace SRP.Entities
{
    internal abstract class Playlist
    {
        protected PlaylistName PlaylistName { get; }
        protected CreationDateUTC CreationDateUTC { get; }
        protected PlaylistVisibility Visibility { get;}

        protected Playlist(
            PlaylistName playlistName, 
            CreationDateUTC creationDateUTC, 
            PlaylistVisibility visibility)
        {
            if (!Enum.IsDefined(visibility))
            {
                throw new ArgumentException("Invalid playlist visibility.", nameof(visibility));
            }

            PlaylistName = playlistName;
            CreationDateUTC = creationDateUTC;
            Visibility = visibility;
        }
    }
}