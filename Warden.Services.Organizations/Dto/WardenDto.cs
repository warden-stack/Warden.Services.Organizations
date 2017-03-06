using System;
using System.Collections.Generic;

namespace Warden.Services.Organizations.Dto
{
    public class WardenDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<WatcherDto> Watchers { get; set; }
    }
}