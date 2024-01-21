using DIYCraftsAndProjectsMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DIYCraftsAndProjectsMVC.Controllers
{
    public class FileController : Controller
    {
        private readonly CraftsAndProjectsDbContext _context;

        // GET: File
        public ActionResult Index(int id)
        {
            var uploadedFile = _context.UploadedFiles.Find(id);

            return File(uploadedFile.FileContent, uploadedFile.FileType);
        }

        // Delete: File
        public ActionResult Delete(int id)
        {
            var uploadedFile = _context.UploadedFiles.Find(id);
            _context.UploadedFiles.Remove(uploadedFile);
            _context.SaveChanges();

            return File(uploadedFile.FileContent, uploadedFile.FileType);
        }
    }
}
