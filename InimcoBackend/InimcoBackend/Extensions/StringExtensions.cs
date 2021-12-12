namespace InimcoBackend.Extensions
{
    public static class StringExtensions
    {
        public static char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        public static int CountVowels(this string targetString)
        {
            return targetString
                .Where(c => char.IsLetter(c))
                .Count(c => vowels.Contains(c));
        }

        public static int CountConsenants(this string targetString)
        {
            return targetString
                .Where(c => char.IsLetter(c))
                .Count(c => !vowels.Contains(c));
        }
    }
}
