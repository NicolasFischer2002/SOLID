using SRP.Entities;

namespace SRP.ValueObjects
{
    internal sealed record YouTubeVideos
    {
        public HashSet<YouTubeVideo> Videos { get; }

        public YouTubeVideos(HashSet<YouTubeVideo> videos)
        {
            Videos = videos ?? [];
        }
    }
}