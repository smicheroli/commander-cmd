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
        private JsonSerializerSettings JsonSerializerSettings;

        public PersistenceService(String filePath) {
            this.FilePath = filePath;
            JsonSerializerSettings= new();
            JsonSerializerSettings.TypeNameHandling= TypeNameHandling.All;
        }

        public void Save(IList<Drive> files)
        {
            System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(files, JsonSerializerSettings));
        }

        public IList<Drive> Load() {

            IList<Drive> files = JsonConvert.DeserializeObject<List<Drive>>(FilePath, JsonSerializerSettings);
            if(files == null)
            {
                files= new List<Drive>();
            }
            return files;
        }
    }
}
