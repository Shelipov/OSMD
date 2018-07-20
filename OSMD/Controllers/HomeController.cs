using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OSMD.Models;
using OSMD.Data;
using OSMD.Data.Migrations;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Net.Http.Headers;


namespace OSMD.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        People people;
        FileModel fileModel;
        
        
        IHostingEnvironment appEnvironment;
        public HomeController(ApplicationDbContext _context, IHostingEnvironment _appEnvironment,People _people,FileModel _fileModel)
        {
            context = _context;
            people = _people;
            appEnvironment = _appEnvironment;
            fileModel = _fileModel;
            
        }
        public IActionResult Index()
        {

            return View(context.People.ToList());
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "ВСЕ НОВОСТИ.";
            
            
            return View(context.News_Table.ToList());

        }
        [HttpGet]
        public IActionResult View_News(int? id)
        {
            ViewData["Message"] = "ВСЕ НОВОСТИ.";
            foreach (var i in context.News_Table)
            {
                if (i.Id == id) { return View(i); }
               

            }

            return View();
        }
        [HttpGet]
        public IActionResult Create_News()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_News(OSMD.Models.News newss, Person pvm, News_Foto news_Foto )
        {

            List<string> Link = new List<string>(10);
            
            if (User.Identity.IsAuthenticated)
            {
                newss._User = User.Identity.Name.ToString();
               
                var name= User.Identity.Name.ToString();
                
                foreach(var i in context.People)
                {
                    if (i.Name == name)
                    {
                        newss.Avatar_News = i.Avatar;
                    }
                }
                
            }
            else
            {
               newss._User = "ANONIM";
                foreach (var i in context.People)
                {
                    if (i.Name == "ANONIM")
                    {
                        newss.Avatar_News = i.Avatar;

                    }
                }

            }
            
            newss.date = DateTime.Now.ToString();
          
            news_Foto.Id = newss.Id;
            if (news_Foto.Foto_Stream != null)
            {
                foreach (var file in news_Foto.Foto_Stream)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        string path = @"C:\Users\sheli\source\repos\OSMD\OSMD\wwwroot\Foto_News\" + newss.news+@"\";
                        
                        DirectoryInfo dirInfo = new DirectoryInfo(path);
                        if (!dirInfo.Exists)
                        {
                            dirInfo.Create();
                        }

                        byte[] fileBytes = null;

                        using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                        {
                            fileBytes = binaryReader.ReadBytes((int)file.Length);
                            using (FileStream fstream = new FileStream((path+fileName), FileMode.OpenOrCreate))
                            {
                                fstream.Write(fileBytes, 0, fileBytes.Length);
                            }
                        }
                        string link = (path + fileName);
                        
                        link = link.Replace(@"C:\Users\sheli\source\repos\OSMD\OSMD\wwwroot", "~");
                        link = link.Replace(@"\", "/");
                        Link.Add(link);
                        
                    }
                }
            }
            string[] Ar = { newss.Link1, newss.Link2, newss.Link3, newss.Link4, newss.Link5,
                        newss.Link6, newss.Link7, newss.Link8, newss.Link9, newss.Link10 };
            
            for (int y = 0; y < 10; y++)
            {
              Ar[y] = Link[y];
            }   //(говнокод)данные не попали в БД почемуто - присваеваем по очереди :
            newss.Link1 = Ar[0]; newss.Link2 = Ar[1]; newss.Link3 = Ar[2]; newss.Link4 = Ar[3]; newss.Link5 = Ar[4];
            newss.Link6 = Ar[5]; newss.Link7 = Ar[6]; newss.Link8 = Ar[7]; newss.Link9 = Ar[8]; newss.Link10 = Ar[9];
            //context.News_Table.Add(news);
            await context.News_Table.AddAsync(newss);
            context.SaveChanges();
            return RedirectToAction("About");
        }

            public IActionResult Contact()
        {
            ViewData["Message"] = "Ваша контактная страница.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // public enum JsonRequestBehavior { };
        public JsonResult GetData() //список для гугл карт
        {
            // создадим список данных
            List<Station> stations = new List<Station>();
            stations.Add(new Station()
            {
                Id = 1,
                PlaceName = "Днепр, ОСМД-65 ул. Рабочая 65",
                GeoLat = 48.451788,
                GeoLong = 35.003862,

            });
            stations.Add(new Station()
            {
                Id = 2,
                PlaceName = "Остановка Межкольный Комбинат",
                GeoLat = 48.450835,
                GeoLong = 35.002531,

            });

            return Json(stations);
        }
        public IActionResult Create_Avatar()
        {
            return View(context.People.ToList());
        }

        [HttpPost]
        public IActionResult Create_Avatar(PersonViewModel pvm, OSMD.Models.ApplicationUser user)
        {
                      
            Person person = new Person ();
            var name = User.Identity.Name.ToString();
            person.Name = name;
            if (pvm.Avatar != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Avatar.Length);
                }
                // установка массива байтов
                person.Avatar = imageData;
                if ((User.Identity.IsAuthenticated)&&(user.Foto==null))
                {
                    foreach (var i in context.People)
                    {
                        if (i.Name == name)
                        {
                            user.Foto = i.Avatar;

                        }
                    }

                    context.Entry(user).State = EntityState.Modified;
                    context.Users.Attach(user);
                    //context.Users.Update(user);
                   
                    context.SaveChanges();
                }
                
            }
           
            
            context.People.Add(person);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                context.Files.Add(file);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFileCollection uploads)
        {
            foreach (var uploadedFile in uploads)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                context.Files.Add(file);
            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        //ИЗМЕНИТЬ АВАТАРКУ
        public IActionResult Edit_Avatar()
        {
            return View(context.People.ToList());
        }
        [HttpPost]
        public IActionResult Edit_Avatar(PersonViewModel pvm, OSMD.Models.ApplicationUser user,Person person)
        {

            
            var name = User.Identity.Name.ToString();
            person.Name = name;
            if (pvm.Avatar != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Avatar.Length);
                }
                // установка массива байтов
                person.Avatar = imageData;
                if ((User.Identity.IsAuthenticated) )//&& (user.Foto == null))
                {
                    foreach (var i in context.Users)
                    {
                        if ((i.UserName == name))
                        {
                            i.Foto = imageData;
                            context.Users.Update(i);
                        }
                       
                    }
                    
                    context.SaveChanges();
                    
                }

            }
            
            context.People.Update(person);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        /// //////////////////////CHAT
       


        /// CHAT




        protected override void Dispose(bool disposing) //отключение от базы
        {
            context.Dispose();
            base.Dispose(disposing);
        }

    }
}