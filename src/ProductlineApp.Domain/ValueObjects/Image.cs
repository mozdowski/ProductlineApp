using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.ValueObjects
{
    public sealed record Image : IFile
    {
        public Image(string name, string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                throw new ArgumentException("Invalid platform URL.", nameof(url));

            this.Name = name;
            this.Url = uri;
        }

        public string Name { get; set; }

        public Uri Url { get; set; }
    }
}
