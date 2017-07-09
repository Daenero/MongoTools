using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MongoTools.Core.Models
{
    public class ProcessWrapper
    {
        private readonly ProcessParameters _parameters;
        private readonly StringBuilder _outputBuilder;
        private readonly Process _process;

        public ProcessWrapper(ProcessParameters parameters)
        {
            _parameters = parameters;
            _outputBuilder = new StringBuilder();
            var processStartInfo = new ProcessStartInfo
            {
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                Arguments = _parameters.ArgumentsString,
                FileName = _parameters.ExecutableName
            };

            _process = new Process
            {
                StartInfo = processStartInfo,
                EnableRaisingEvents = true
            };


            //_process.
        }

        public void StartAndWait()
        {
            _process.OutputDataReceived += WriteOutput;
            _process.ErrorDataReceived += WriteOutput;
            // start the process
            // then begin asynchronously reading the output
            // then wait for the process to exit
            // then cancel asynchronously reading the output
            _process.Start();
            _process.BeginErrorReadLine();
            _process.WaitForExit();
            _process.CancelOutputRead();
            var a = _process.StandardError.ReadToEnd();

        }

        public string GetText()
        {
            return _outputBuilder.ToString();
        }

        private void WriteOutput(object sender, DataReceivedEventArgs e)
        {
            _outputBuilder.AppendLine(e.Data);
        }
    }
}