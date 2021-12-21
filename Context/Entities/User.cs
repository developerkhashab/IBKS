using IBKS.Models;
using System;
using System.Collections.Generic;

namespace IBKS.Context.Entities
{
    public class User : ApiModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime DOB { get; set; }

        public IList<Post> Posts { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
