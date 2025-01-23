using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {   // TODO Problem 1 - ADD YOUR CODE HERE
        var pairs = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());
            if (seen.Contains(reversed))
            {
                pairs.Add($"{word} & {reversed}");
            }
            seen.Add(word);
        }
        return pairs.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        string Normalize(string word) => new string(word.ToLower().Where(char.IsLetter).OrderBy(c => c).ToArray());

        return Normalize(word1) == Normalize(word2);
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<EarthquakeFeatureCollection>(json, options);

        // TODO Problem 5:
        var results = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var magnitude = feature.Properties.Mag;
            results.Add($"Location: {place}, Magnitude: {magnitude}");
        }

        return results.ToArray();
    }
}

public class EarthquakeFeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}