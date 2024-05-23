using Assesment.Data;
using Assesment.Services;

namespace Assessment.Tests
{
    public class TestsFixture : IDisposable
    {
        public IAvatarData AvatarData { get; set; }

        public TestsFixture()
        {
            var restClient = new RestClient();
            var dbContext = new AvatarDatabaseContext();
            var avatarImageRepository = new AvatarImageRepository(dbContext);

            AvatarData = new AvatarData(restClient, avatarImageRepository);
        }

        public void Dispose()
        {
            // "global" teardown
        }
    }

    public class APITests : IClassFixture<TestsFixture>
    {
        private readonly IAvatarData _avatarData;

        public APITests(TestsFixture data)
        {
            _avatarData = data.AvatarData;
        }

        [Theory]
        [InlineData("6","6")]
        [InlineData("a6", "6")]
        [InlineData("66", "6")]
        [InlineData("!6", "6")]
        [InlineData("7", "7")]
        [InlineData("d7", "7")]
        [InlineData("87", "7")]
        [InlineData("@7", "7")]
        [InlineData("8", "8")]
        [InlineData("g8", "8")]
        [InlineData("18", "8")]
        [InlineData("^8", "8")]
        [InlineData("9", "9")]
        [InlineData("H9", "9")]
        [InlineData("09", "9")]
        [InlineData("#9", "9")]
        public void When_last_character_is_6789(string input, string output)
        {
            // Arrange
            string actualURL = $"https://api.dicebear.com/8.x/pixel-art/png?seed={output}&size=150";

            // Act
            string resultURL = _avatarData.GetAvatarInfo(input).URL;

            // Assert
            Assert.Equal(actualURL, resultURL);
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("a1", "1")]
        [InlineData("21", "1")]
        [InlineData("!1", "1")]
        [InlineData("2", "2")]
        [InlineData("b2", "2")]
        [InlineData("32", "2")]
        [InlineData("@2", "2")]
        [InlineData("3", "3")]
        [InlineData("c3", "3")]
        [InlineData("43", "3")]
        [InlineData("#3", "3")]
        [InlineData("4", "4")]
        [InlineData("d4", "4")]
        [InlineData("54", "4")]
        [InlineData("$4", "4")]
        [InlineData("5", "5")]
        [InlineData("e5", "5")]
        [InlineData("65", "5")]
        [InlineData("%5", "5")]
        public void When_last_character_is_12345(string input, string output)
        {
            // Arrange
            string actualURL = $"https://api.dicebear.com/8.x/pixel-art/png?seed={output}&size=150";

            // Act
            string resultURL = _avatarData.GetAvatarInfo(input).URL;

            // Assert
            Assert.Equal(actualURL, resultURL);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("xa")]
        [InlineData("ax")]
        [InlineData("axa")]
        [InlineData("xax")]
        [InlineData("1a")]
        [InlineData("a1a")]
        [InlineData("aa0")]
        [InlineData("!a")]
        [InlineData("a!")]
        [InlineData("a!a")]
        [InlineData("!a!")]
        [InlineData("A")]
        [InlineData("xA")]
        [InlineData("Ax")]
        [InlineData("AxA")]
        [InlineData("xAx")]
        [InlineData("1A")]
        [InlineData("A1A")]
        [InlineData("AA0")]
        [InlineData("!A")]
        [InlineData("A!")]
        [InlineData("A!A")]
        [InlineData("!A!")]
        [InlineData("e")]
        [InlineData("xe")]
        [InlineData("ex")]
        [InlineData("exe")]
        [InlineData("xex")]
        [InlineData("1e")]
        [InlineData("e1e")]
        [InlineData("ee0")]
        [InlineData("!e")]
        [InlineData("e!")]
        [InlineData("e!e")]
        [InlineData("!e!")]
        [InlineData("E")]
        [InlineData("xE")]
        [InlineData("Ex")]
        [InlineData("ExE")]
        [InlineData("xEx")]
        [InlineData("1E")]
        [InlineData("E1E")]
        [InlineData("EE0")]
        [InlineData("!E")]
        [InlineData("E!")]
        [InlineData("E!E")]
        [InlineData("!E!")]
        [InlineData("ix")]
        [InlineData("ixi")]
        [InlineData("xix")]
        [InlineData("1i")]
        [InlineData("i1i")]
        [InlineData("ii0")]
        [InlineData("!i")]
        [InlineData("i!")]
        [InlineData("i!i")]
        [InlineData("!i!")]
        [InlineData("I")]
        [InlineData("xI")]
        [InlineData("Ix")]
        [InlineData("IxI")]
        [InlineData("xIx")]
        [InlineData("1I")]
        [InlineData("I1I")]
        [InlineData("II0")]
        [InlineData("!I")]
        [InlineData("I!")]
        [InlineData("I!I")]
        [InlineData("!I!")]
        [InlineData("ox")]
        [InlineData("oxo")]
        [InlineData("xox")]
        [InlineData("1o")]
        [InlineData("o1o")]
        [InlineData("oo0")]
        [InlineData("!o")]
        [InlineData("o!")]
        [InlineData("o!o")]
        [InlineData("!o!")]
        [InlineData("O")]
        [InlineData("xO")]
        [InlineData("Ox")]
        [InlineData("OxO")]
        [InlineData("xOx")]
        [InlineData("1O")]
        [InlineData("O1O")]
        [InlineData("OO0")]
        [InlineData("!O")]
        [InlineData("O!")]
        [InlineData("O!O")]
        [InlineData("!O!")]
        [InlineData("ux")]
        [InlineData("uxu")]
        [InlineData("xux")]
        [InlineData("1u")]
        [InlineData("u1u")]
        [InlineData("uu0")]
        [InlineData("!u")]
        [InlineData("u!")]
        [InlineData("u!u")]
        [InlineData("!u!")]
        [InlineData("U")]
        [InlineData("xU")]
        [InlineData("Ux")]
        [InlineData("UxU")]
        [InlineData("xUx")]
        [InlineData("1U")]
        [InlineData("U1U")]
        [InlineData("UU0")]
        [InlineData("!U")]
        [InlineData("U!")]
        [InlineData("U!U")]
        [InlineData("!U!")]
        [InlineData("aeiou")]
        [InlineData("AEIOU")]
        [InlineData("aeiou0")]
        [InlineData("AEIOU0")]
        [InlineData("1aeiou")]
        [InlineData("1AEIOU")]
        public void When_at_least_one_vowel_is_present(string input)
        {
            // Arrange
            string actualURL = "https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150";

            // Act
            string resultURL = _avatarData.GetAvatarInfo(input).URL;

            // Assert
            Assert.Equal(actualURL, resultURL);
        }

        [Theory]
        [InlineData("bb!")]
        [InlineData("b!b")]
        [InlineData("!bb")]
        [InlineData("12!")]
        public void When_one_non_alphanumeric_character_is_present(string input)
        {
            // Arrange
            string actualURLPrefix = "https://api.dicebear.com/8.x/pixel-art/png?seed=";
            string actualURLSuffix = "&size=150";

            // Act
            string resultURL = _avatarData.GetAvatarInfo(input).URL;
            
            string resultURLPrefix = resultURL.Substring(0, 48);
            string seed = resultURL.Substring(48, 1);
            string resultURLSuffix = resultURL.Substring(resultURL.Length - 9, 9);

            int.TryParse(seed, out int seedNumber);

            // Assert
            Assert.Equal(actualURLPrefix, resultURLPrefix);
            Assert.InRange(seedNumber, 1, 5);
            Assert.Equal(resultURLSuffix, resultURLSuffix);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("BCD")]
        [InlineData("FGH")]
        [InlineData("JKLMN")]
        [InlineData("PQRST")]
        [InlineData("WXYZ")]
        [InlineData("BCDFGHJKLMNPQRSTWXYZ")]
        public void Default_URL(string? input)
        {
            // Arrange
            string actualURL = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150";

            // Act
            string resultURL = _avatarData.GetAvatarInfo(input).URL;

            // Assert
            Assert.Equal(actualURL, resultURL);
        }
    }
}