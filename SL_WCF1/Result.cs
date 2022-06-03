using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SL_WCF1
{
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public object Objetc { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
    }
}