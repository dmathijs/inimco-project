namespace InimcoBackend.Models.ProfileRetrieval
{
    public class ProfileWrapperRetrievalDto
    {
        public ProfileRetrievalDto? OriginalProfile { get; set; }

        public int NumberOfVowelsInFirstAndLastName { get; set; }
        public int NumberOfConsonantsInFirstAndLastName { get; set; }

        public string Name => $"{OriginalProfile?.FirstName} {OriginalProfile?.LastName}";
        public string? ReversedName => new string(Name.Reverse().ToArray());
    }
}
