using System.Collections.Generic;

namespace IFSP.ADS.Infrastructure
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Errors = new List<Error>();

        }

        public bool HasError
        {
            get
            {
                return Errors.Count > 0;
            }
        }
        public IList<Error> Errors { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
