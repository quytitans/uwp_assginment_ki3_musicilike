using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainStudyApp.Entity
{
    class Credential
    {
        public string token { get; set; }
        public string secretToken { get; set; }
        public double userId { get; set; }
        public long createdTimeMLS { get; set; }
        public long expiredTimeMLS { get; set; }
        public int status { get; set; }

    }
}
