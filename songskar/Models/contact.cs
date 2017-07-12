using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace songskar.Models
{
    public class contact
    {
        public int ContactId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
        public DateTime PubDate { get; set; }
    }
}