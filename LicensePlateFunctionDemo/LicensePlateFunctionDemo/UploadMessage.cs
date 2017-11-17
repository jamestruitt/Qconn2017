using System;

namespace LicensePlateFunctionDemo
{
    internal class UploadMessage
    {
        public UploadMessage()
        {
        }

        public string FileName { get; internal set; }
        public string URL { get; internal set; }
        public DateTime ReceivedDate { get; internal set; }
    }
}