﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace songskar.Models
{
    public class aungkur
    {
        public int AungkurId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
        public DateTime PubDate { get; set; }
    }
}