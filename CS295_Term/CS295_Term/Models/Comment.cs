using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_Term.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public string CommentText { get; set; }

        public SiteUser CommentUser { get; set; }

    }
}
