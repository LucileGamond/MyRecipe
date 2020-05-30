using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Step : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rank { get; set; }

        public Recipe Recipe { get; set; }
    }
}
