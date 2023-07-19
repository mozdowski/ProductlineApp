using ProductlineApp.Domain.Common.Abstractions;

namespace ProductlineApp.Domain.ValueObjects
{
    public sealed record Image : IFile
    {
        private Image(string name, string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                throw new ArgumentException("Invalid platform URL.", nameof(url));

            this.Name = name;
            this.Url = uri;
        }

        private Image(string name, Uri uri)
        {
            this.Name = name;
            this.Url = uri;
        }

        private Image()
        {
        }

        public static Image Create(string url)
        {
            var name = url.Split('/')[^1].Split('.')[0];
            return new Image(name, url);
        }

        public static Image Create(string name, string url)
        {
            return new Image(name, url);
        }

        public static Image Create(string name, Uri uri)
        {
            return new Image(name, uri);
        }

        public string Name { get; set; }

        public Uri Url { get; set; }

        public bool Equals(Image? other)
        {
            if (other is null)
                return false;

            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public string GetUrlStringWithoutQueryParams()
        {
            string baseUri = this.Url.GetLeftPart(UriPartial.Authority);
            string pathWithoutQuery = this.Url.AbsolutePath;

            return baseUri + pathWithoutQuery;
        }
    }
}
