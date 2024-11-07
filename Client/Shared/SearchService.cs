public class SearchService
{
    public string SearchTerm { get; set; } = string.Empty;

    // Event for notifying when the search term changes
    public event Action<string> OnSearchTermChanged;

    public void SetSearchTerm(string term)
    {
        SearchTerm = term;
        OnSearchTermChanged?.Invoke(SearchTerm);
    }
}
