using System;
using System.IO;

namespace Carubbi.Logger
{
    /// <summary>
    ///     Logger responsável pela gravação em arquivos no file system
    /// </summary>
    public class FileLogger : Logger
    {
        private const string FILE_NAME_DEFAULT = "Log.txt";
        private readonly string _fileName = string.Empty;


        public FileLogger()
            : base(LogLevel.All)
        {
            _fileName = FILE_NAME_DEFAULT;
        }


        public FileLogger(LogLevel mask)
            : base(mask)
        {
            _fileName = FILE_NAME_DEFAULT;
        }

        public FileLogger(Func<string, string> formatMessageHandler)
            : base(LogLevel.All, formatMessageHandler)
        {
            _fileName = FILE_NAME_DEFAULT;
        }


        public FileLogger(string filename)
            : base(LogLevel.All)
        {
            _fileName = filename;
        }

        public FileLogger(Func<string, string> formatMessageHandler, string filename)
            : base(LogLevel.All, formatMessageHandler)
        {
            _fileName = filename;
        }

        public FileLogger(LogLevel mask, string filename)
            : base(mask)
        {
            _fileName = filename;
        }


        public FileLogger(LogLevel mask, Func<string, string> formatMessageHandler)
            : this(mask, formatMessageHandler, FILE_NAME_DEFAULT)
        {
        }


        public FileLogger(LogLevel mask, Func<string, string> formatMessageHandler, string filename)
            : base(mask, formatMessageHandler)
        {
            _fileName = filename;
        }

        protected override void WriteMessage(string msg)
        {
            File.AppendAllText(_fileName, msg);
        }
    }
}