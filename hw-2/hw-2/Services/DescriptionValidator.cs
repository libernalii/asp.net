namespace hw_2.Services
{
    public class DescriptionValidator
    {
        private readonly string[] _forbiddenWords =
        {
        "badword",
        "spam",
        "hack"
    };

        public bool IsValid(string description)
        {
            foreach (var word in _forbiddenWords)
            {
                if (description.ToLower().Contains(word))
                    return false;
            }
            return true;
        }
    }
}
