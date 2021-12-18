using IBKS.Models;
using System.Collections.Generic;

namespace IBKS.Context.Entities
{
    public class Post : ApiModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
