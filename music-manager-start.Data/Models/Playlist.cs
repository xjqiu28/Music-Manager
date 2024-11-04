using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_manager_starter.Data.Models
{
    public sealed class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }

    }
}
