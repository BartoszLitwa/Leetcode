public class Codec {
    private Dictionary<string, string> encodeMap;
    private Dictionary<string, string> decodeMap;
    private const string domain = "http://tinyurl.com/";

    public Codec(){
        encodeMap = new Dictionary<string, string>();
        decodeMap = new Dictionary<string, string>();
    }

    // Encodes a URL to a shortened URL
    public string encode(string longUrl) {
        if(!encodeMap.ContainsKey(longUrl)){ // Add new
            // Convert to base64 string
            var bytes = BitConverter.GetBytes(encodeMap.Count + 1);
            var encoded = Convert.ToBase64String(bytes)[0..6];
            // Add to maps
            encodeMap.Add(longUrl, encoded);
            decodeMap.Add(encoded, longUrl);
        }

        return $"{domain}{encodeMap[longUrl]}";
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        string shortDecode = shortUrl[(domain.Length)..]; // Remove domain
        if(!decodeMap.ContainsKey(shortDecode)) // Not found
            return string.Empty;

        return decodeMap[shortDecode]; // Return original url
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));