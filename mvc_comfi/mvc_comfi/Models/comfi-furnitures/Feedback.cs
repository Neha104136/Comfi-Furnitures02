using System;
using System.Collections.Generic;

#nullable disable

namespace mvc_comfi.Models.comfi
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Suggestions { get; set; }
    }
}
