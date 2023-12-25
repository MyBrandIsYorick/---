using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using TranslatorDLL;

namespace FileService
{
    public class File_Service
    {
        private readonly string PATH;

        public File_Service(string path)
        {
            PATH=path;
        }
        public BindingList<Translator_Class> LoadData()
        {
            var fileexists = File.Exists(PATH);
            if (!fileexists)
            {
                File.Create(PATH).Dispose();
                return new BindingList<Translator_Class>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Translator_Class>>(fileText);
            }
        }
        public void SaveData(object _translatorlist)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(_translatorlist);
                writer.Write(output);
            }
        }
    }
}
