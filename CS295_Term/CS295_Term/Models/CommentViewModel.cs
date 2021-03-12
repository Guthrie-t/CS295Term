using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS295_Term.Models
{
    public class CommentViewModel
    {
        public int RecId { get; set; } //for the recipe being commented on

        public string CommentText { get; set; }

    }
}
