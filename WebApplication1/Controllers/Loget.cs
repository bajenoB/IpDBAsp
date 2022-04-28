using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaveFile : ControllerBase
    {
        private readonly ILogger<SaveFile> _logger;
        private string path;
        private DataBase dataBase;
        public SaveFile(ILogger<SaveFile> logger)
        {
            _logger = logger;
            path = @$"C:\Users\{Environment.UserName}\tmpDir";
            dataBase = new DataBase();
            dataBase.ConnectToDB();
        }
        [HttpPost]
        public void Save_FileIP()
        {
            byte[] info;
            if (!Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            System.IO.File.WriteAllText(path + @$"\{Environment.UserName}.txt",
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString());
            info = System.IO.File.ReadAllBytes(path + $@"\{Environment.UserName}.txt");

            dataBase.InsertFile(Environment.UserName + ".txt", info);



        }
    }
}
