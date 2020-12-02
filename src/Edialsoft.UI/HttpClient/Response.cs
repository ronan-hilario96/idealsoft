using System;
using System.Collections.Generic;
using System.Text;

namespace Edialsoft.UI.HttpClient
{
    public class Response
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public List<string> Messages { get; set; } = new List<string>();
    }
}
