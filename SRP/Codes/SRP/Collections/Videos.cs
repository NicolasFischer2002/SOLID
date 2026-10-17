using SRP.Entities;

namespace SRP.Collections
{
    internal sealed class Videos
    {
        private readonly List<Video> _value;

        public Videos()
        {
            _value = [];
        }

        public Videos(IEnumerable<Video> videos)
        {
            ArgumentNullException.ThrowIfNull(videos, nameof(videos));

            _value = [.. videos];

            if (_value.Any(video => video is null))
                throw new ArgumentException(
                    "The video collection cannot contain null items.",
                    nameof(videos));
        }

        public IReadOnlyList<Video> GetVideos() => _value.AsReadOnly();

        public void Add(Video video)
        {
            ArgumentNullException.ThrowIfNull(video, nameof(video));

            _value.Add(video);
        }

        public bool Remove(Guid videoId)
        {
            var index = _value.FindIndex(video => video.Id == videoId);

            if (index < 0)
                return false;

            _value.RemoveAt(index);
            return true;
        }
    }
}