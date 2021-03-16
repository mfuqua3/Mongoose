using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Mongoose.Models;

namespace Mongoose.Service
{
    public interface IVideoFileService
    {
        /// <summary>
        /// Returns all files in the webroot directory with a *.m4v file extension
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FileInfoViewModel>> GetAllVideoFiles();
        /// <summary>
        /// Returns all files in the webroot directory with a *.m4v file extension that have not been mapped to an Episode or Film entity in the database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<FileInfoViewModel>> GetUnmappedVideoFiles();
    }
}