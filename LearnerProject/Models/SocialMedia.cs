using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }
    }
}