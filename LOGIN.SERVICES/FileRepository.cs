using LOGIN.SERVICES.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIN.SERVICES
{
    public class FileRepository: IFileRepository
    {
        public bool FileExtentionControl(string FileExtention)
        {
            if (FileExtention != ".pdf" && FileExtention != ".doc" && FileExtention != ".docx")
            {
                return true;
            }

            return false;
        }
    }
}
