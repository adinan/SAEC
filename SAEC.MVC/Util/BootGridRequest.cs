using System.Collections.Generic;

namespace SAEC.MVC.Util
{
    public class BootGridRequest
    {
        public int current { get; set; }

        public int rowCount { get; set; }

        public Dictionary<string, string> sort { get; set; }

        public string searchphrase { get; set; }
    }

    public class BootGridResponse
    {
        public int current { get; set; }

        public int total { get; set; }

        public int rowCount { get; set; }

        public dynamic rows { get; set; }

    }
}