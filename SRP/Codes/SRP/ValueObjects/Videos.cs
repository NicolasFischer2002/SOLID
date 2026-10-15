using SRP.Entities;

namespace SRP.ValueObjects
{
    internal sealed record Videos
    {
        private HashSet<Video> Value { get; }

        public Videos(HashSet<Video> videos)
        {
            Value = videos ?? [];
        }

        public IReadOnlyCollection<Video> GetVideos() => Value;

        public void Add(Video video)
        {
            Value.Add(video);
        }
    }
}