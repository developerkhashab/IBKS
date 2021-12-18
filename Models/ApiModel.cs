using IBKS.Models.Interfaces;
using System;

namespace IBKS.Models
{
    public class ApiModel : IApiModel
    {
        public int Id { get; set; }

        public bool IsRemoved { get; set; } = false;

        public DateTime CreatedDate { get; set; }

        public DateTime LastModified { get; set; }
    }
}
