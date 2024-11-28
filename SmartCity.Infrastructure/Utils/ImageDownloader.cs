namespace SmartCity.Infrastructure.Utils;

public static class ImageDownloader {
    public static async Task DownloadImagesAsync(List<string> imageUrls, string outputDirectory) {
        // Create directory if it doesn't exist
        Directory.CreateDirectory(outputDirectory);

        using HttpClient client = new HttpClient();

        // Download images concurrently
        var downloadTasks = new List<Task>();
        foreach (var url in imageUrls) {
            downloadTasks.Add(DownloadImageAsync(client, url, outputDirectory));
        }

        await Task.WhenAll(downloadTasks);

        Console.WriteLine("All images have been downloaded.");
    }

    private static async Task DownloadImageAsync(HttpClient client, string imageUrl, string outputDirectory) {
        try {
            Console.WriteLine($"Downloading {imageUrl}...");

            // Send GET request
            var response = await client.GetAsync(imageUrl);
            response.EnsureSuccessStatusCode();

            // Get content type and determine file extension
            string contentType = response.Content.Headers.ContentType?.MediaType;
            string extension = GetExtensionFromContentType(contentType);

            if (string.IsNullOrEmpty(extension)) {
                Console.WriteLine($"Unsupported content type for URL: {imageUrl}");
                return;
            }

            // Generate unique file name
            string fileName = Guid.NewGuid() + extension;
            string outputPath = Path.Combine(outputDirectory, fileName);

            // Save image to file
            byte[] imageData = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(outputPath, imageData);

            Console.WriteLine($"Saved {fileName} to {outputPath}");
        } catch (Exception ex) {
            Console.WriteLine($"Failed to download {imageUrl}: {ex.Message}");
        }
    }

    private static string GetExtensionFromContentType(string contentType) {
        return contentType switch {
            "image/jpeg" => ".jpg",
            "image/png" => ".png",
            "image/gif" => ".gif",
            "image/webp" => ".webp",
            _ => string.Empty // Unknown file type
        };
    }
}