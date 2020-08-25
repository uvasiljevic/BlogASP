using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class UseCaseLogs
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Actor { get; set; }
        public string Data { get; set; }
    }
}
