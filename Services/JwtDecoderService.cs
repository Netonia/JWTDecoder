using System.Text;
using System.Text.Json;

namespace JWTDecoder.Services;

public class JwtDecoderService
{
    public JwtDecodedResult DecodeJwt(string jwt)
    {
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return new JwtDecodedResult
            {
                Success = false,
                ErrorMessage = "JWT token is empty."
            };
        }

        var parts = jwt.Trim().Split('.');
        
        if (parts.Length != 3)
        {
            return new JwtDecodedResult
            {
                Success = false,
                ErrorMessage = $"Invalid JWT format. Expected 3 parts (header.payload.signature), but found {parts.Length}."
            };
        }

        try
        {
            var header = DecodeBase64UrlToJson(parts[0]);
            var payload = DecodeBase64UrlToJson(parts[1]);

            return new JwtDecodedResult
            {
                Success = true,
                Header = header,
                Payload = payload,
                Signature = parts[2]
            };
        }
        catch (FormatException)
        {
            return new JwtDecodedResult
            {
                Success = false,
                ErrorMessage = "Invalid Base64 encoding in JWT token."
            };
        }
        catch (JsonException ex)
        {
            return new JwtDecodedResult
            {
                Success = false,
                ErrorMessage = $"Invalid JSON in JWT token: {ex.Message}"
            };
        }
        catch (Exception ex)
        {
            return new JwtDecodedResult
            {
                Success = false,
                ErrorMessage = $"Error decoding JWT: {ex.Message}"
            };
        }
    }

    private string DecodeBase64UrlToJson(string base64Url)
    {
        // Convert Base64Url to Base64
        var base64 = base64Url.Replace('-', '+').Replace('_', '/');
        
        // Add padding if necessary
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        // Decode from Base64
        var bytes = Convert.FromBase64String(base64);
        var json = Encoding.UTF8.GetString(bytes);

        // Validate and pretty-print JSON
        var jsonDocument = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(jsonDocument, new JsonSerializerOptions { WriteIndented = true });
    }
}

public class JwtDecodedResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public string? Header { get; set; }
    public string? Payload { get; set; }
    public string? Signature { get; set; }
}
