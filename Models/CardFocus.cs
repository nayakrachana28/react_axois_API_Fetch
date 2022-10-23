using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace react_axois_API_Fetch.Models
{
    public partial class CardFocus
    {
        [Key]
        public int Id { get; set; }
        public string? FocusImage { get; set; }
        public string? FocusTitle { get; set; }
        public string? FocusDesc { get; set; }
    }
}
