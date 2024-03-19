﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.Interfaces
{
    public interface ILoggerService
    {
        public void LogInformation(string msg);

        public void LogWarning(string msg);

        public void LogTrace(string msg);

        public void LogDebug(string msg);

        public void LogError(object request, string errorMsg);
        public void LogGlobalError(string errorMsg);
    }
}
