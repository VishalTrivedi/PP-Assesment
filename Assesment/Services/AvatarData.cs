using Assesment.Data;
using Assesment.Models;

namespace Assesment.Services;

public class AvatarData : IAvatarData
{
    private readonly IRestClient _restClient;

    private readonly IAvatarImageRepository _avatarImageRepository;

    public AvatarData(
        IRestClient restClient,
        IAvatarImageRepository avatarRepository)
    {
        _restClient = restClient;
        _avatarImageRepository = avatarRepository;
    }

    public AvatarInfo GetAvatarInfo(string? identifier)
    {
        return new AvatarInfo()
        {
            URL = DetermineAvatarImageURL(identifier)
        };
    }

    private string DetermineAvatarImageURL(string? identifier)
    {
        string defaultURL = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150";

        try
        {
            // If the identifier is null or empty return default URL
            if (!string.IsNullOrWhiteSpace(identifier))
            {
                identifier = identifier.Trim();

                string lastChar = identifier.Substring(identifier.Length - 1, 1);
                if (int.TryParse(lastChar, out int lastNum))
                {
                    // Condition 1: If the last character is 6, 7, 8 or 9
                    if (lastNum > 5)
                    {
                        string imageURL = $"https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{lastChar}";

                        // Get Image from service
                        return _restClient.GetImageURL(imageURL);
                    }
                    // Condition 2: If the last character is 1, 2, 3, 4 or 5
                    else if (lastNum > 0)
                    {
                        // Get from DB
                        return _avatarImageRepository.GetById(lastNum).ImageURL;
                    }
                }

                // Condition 3: If identifier contains at least one vowel
                if (HasOneVowel(identifier))
                {
                    return "https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150";
                }
                // Condition 4: If identifier contains at least one non-alphanumeric character
                else if (HasNonAlphaNumChar(identifier))
                {
                    Random rnd = new Random();
                    int randomNumber = rnd.Next(1, 5);

                    return $"https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150";
                }
            }
        }
        catch (Exception ex)
        {
            // Log error
        }

        return defaultURL;
    }

    private static bool HasOneVowel(string identifier)
    {
        char[] letters = identifier.ToCharArray();
        string vowels = "aeiouAEIOU";

        for(int i = 0; i < letters.Length; i++)
        {
            if (vowels.IndexOf(letters[i]) >= 0)
            {
                return true;
            }
        }

        return false;        
    }

    private static bool HasNonAlphaNumChar(string identifier)
    {
        return identifier.Any(ch => !char.IsLetterOrDigit(ch));
    }
}
