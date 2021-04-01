using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIN.SERVICES.IRepository
{
    public interface IFileRepository
    {
        public bool FileExtentionControl(string FileExtention);
    }
}
