//using DIYCraftsAndProjectsMVC.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;

//namespace DIYCraftsAndProjectsMVC.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly CraftsAndProjectsDbContext _context;

//        public HomeController(ILogger<HomeController> logger, CraftsAndProjectsDbContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }

//        // GET: Project
//        public ActionResult Index()
//        {
//            return View(_context.Posts);
//        }

//        // GET: Project/Details/5
//        public ActionResult Details(int? id)
//        {
//            return CommonAction(id);
//        }

//        // GET: Project/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Project/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(
//            Post post,
//            IEnumerable<HttpPostedFileBase> files // pokupt će multipath request sve file-ove
//            )
//        {
//            if (ModelState.IsValid)
//            {
//                project.UploadedProjects = new List<UploadedProject>();
//                AddFiles(project, files);
//                db.Projects.Add(project);
//                db.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(project);
//        }

//        private void AddFiles(Project project, IEnumerable<HttpPostedFileBase> files)
//        {
//            foreach (var file in files)
//            {
//                if (file != null && file.ContentLength > 0)
//                {
//                    var picture = new UploadedProject
//                    {
//                        ContentType = file.ContentType,
//                        Name = file.FileName
//                    };

//                    // content
//                    using (var reader = new System.IO.BinaryReader(file.InputStream))
//                    {
//                        picture.Content = reader.ReadBytes(file.ContentLength);
//                    }


//                    project.UploadedProjects.Add(picture);
//                }
//            }
//        }

//        // GET: Project/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            return CommonAction(id);
//        }

//        // POST: Project/Edit/5
//        [HttpPost]
//        public ActionResult Edit(
//            int id,
//            IEnumerable<HttpPostedFileBase> files) // id bez kolekcije
//        {
//            var project = db.Projects.Find(id);

//            if (TryUpdateModel(
//                project, // entitet koji update-am
//                "", // default value -> nemam
//                new string[] // dinamički string
//                {
//                    nameof(Project.Name), // vrijednosti koje dolaze iz forme
//                    nameof(Project.Description)
//                }
//                ))
//            {
//                AddFiles(project, files);

//                db.Entry(project).State = EntityState.Modified; // flag da se promijenio
//                db.SaveChanges();
//                return RedirectToAction(nameof(Index));
//            }

//            return View(project);
//        }

//        // GET: Project/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            return CommonAction(id);
//        }

//        private ActionResult CommonAction(int? id)
//        {
//            if (id == null) // ako obrisem id iz url-a
//            {
//                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
//            }
//            var project = db.Projects
//                .Include(p => p.UploadedProjects)
//                .SingleOrDefault(p => p.IDProject == id);
//            if (project == null)
//            {
//                return HttpNotFound(); // ako posaljem nepostojeci id
//            }
//            return View(project);
//        }

//        // POST: Project/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            db.UploadedProjects.RemoveRange(db.UploadedProjects.Where(
//                f => f.ProjectIDProject == id));
//            db.Projects.Remove(db.Projects.Find(id));
//            db.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
