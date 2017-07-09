using System;
using System.IO;

namespace MongoTools.Core.Models
{
    public class ProcessParameters
    {
        private string _executableName;

        public ProcessParameters(string exeName)
        {
            _executableName = exeName;
        }

        public string ArgumentsString => "2>&1";

        public string ExecutableName => Path.Combine(AppContext.BaseDirectory, "MongoBinary", _executableName);

        public static ProcessParameters MongoDump => new ProcessParameters("mongodump.exe");
    }
}