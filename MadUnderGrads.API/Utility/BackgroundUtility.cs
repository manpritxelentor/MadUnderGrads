using Hangfire;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MadUnderGrads.API.Utility
{
    public class BackgroundUtility : IBackgroundUtility
    {
        public void DeleteFile(string filePath)
        {
            BackgroundJob.Enqueue(() => DeletePhysicalFile(filePath));
        }

        private void DeletePhysicalFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }

    public interface IBackgroundUtility
    {
        void DeleteFile(string filePath);
    }
}