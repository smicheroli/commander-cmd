using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace commandercmd.FileSystem
{
    public class PersistenceService
    {
        public String FilePath { get; set; }
        private JsonSerializerSettings jsonSerializerSettings;

        public PersistenceService(String filePath) {
            this.FilePath = filePath;
            jsonSerializerSettings = new();
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
        }

        public void Save(IList<Drive> files)
        {
            System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(files,jsonSerializerSettings));
        }

        public IList<Drive> Load() {
            IList<Drive> files = new List<Drive>();
            if (System.IO.File.Exists(FilePath))
            {
                files = JsonConvert.DeserializeObject<List<Drive>>(System.IO.File.ReadAllText(FilePath),jsonSerializerSettings);
            } else
            {
                files= new List<Drive>();
                Drive cDrive = new Drive('C');
                Directory directory1 = new Directory("Pema");
                directory1.Content.Add(new File("Loris.txt", "Das ist ein Test. Diktaturen verboten"));


                directory1.Content.Add(new Directory("Loris"));
                cDrive.Content.Add(directory1);


                Directory directory2 = new Directory("Pema1");
                cDrive.Content.Add(directory2);
                Directory directory3 = new Directory("Pema2");
                cDrive.Content.Add(directory3);
                files.Add(cDrive);
            }
            return files;
        }
    }
}
