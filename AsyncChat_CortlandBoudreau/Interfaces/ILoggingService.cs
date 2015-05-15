using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{

    /// <summary>
    /// Interface used to integegate logging services via injection
    /// Accept string and call log method based on the object
    /// </summary>
    public interface ILoggingService
    {
        void Log(string message);
    }
}
