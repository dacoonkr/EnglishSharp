using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishSharp
{
    class ResultStatus
    {
        public Status status = Status.Unknown;
        public string content = string.Empty;

        public ResultStatus(Status status, string content)
        {
            this.status = status;
            this.content = content;
        }
    }

    enum Status : int
    {
        Unknown = -1,
        Success = 0,
        TransfileError = 1,
        CS_CompileError = 2,
    }
}