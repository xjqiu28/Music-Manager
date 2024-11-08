// Services/SearchService.cs
using System;
using System.Threading.Tasks;

namespace music_manager_starter.Services
{
    public class SearchService
    {
        public event Action? OnSearchChanged;

        private string _searchTerm = string.Empty;
        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                if (_searchTerm != value)
                {
                    _searchTerm = value;
                    OnSearchChanged?.Invoke();
                }
            }
        }
    }
}