using System.ComponentModel;
using TranslatorDLL;
using FileService;
using System.IO;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
     
        [TestMethod]
        public void CheckisEmptyObjectExist()
        {
            bool EmptyObject = false;
            bool Expexted = false;
            BindingList<Translator_Class> _translatorlist;
            File_Service _service;
            string PATH = @"C:\Users\denep\OneDrive\Desktop\Важное\Домашка_ПТУ\C#\Лаба-Новогодняя\Лаба-Новогодняя\bin\Debug\net7.0-windows\Translate_Lib.json";
            _service = new File_Service(PATH);
            _translatorlist =_service.LoadData();
            for (int i = 0;i< _translatorlist.Count;i++)
            {
                if (_translatorlist[i].Word==null||_translatorlist[i].Translation==null)
                {
                    EmptyObject = true;
                    break;
                }
            }
            Assert.AreEqual(EmptyObject,Expexted);
        }
        [TestMethod]
        public void CheckFirstLetters()
        {
            bool Expected = false;
            bool UpperandLowercase = false;
            BindingList<Translator_Class> _translatorlist;
            File_Service _service;
            string PATH = @"C:\Users\denep\OneDrive\Desktop\Важное\Домашка_ПТУ\C#\Лаба-Новогодняя\Лаба-Новогодняя\bin\Debug\net7.0-windows\Translate_Lib.json";
            _service = new File_Service(PATH);
            _translatorlist =_service.LoadData();
            for (int i=0;i< _translatorlist.Count; i++)
            {
                if (Char.IsUpper(_translatorlist[i].Word[0])!=Char.IsUpper(_translatorlist[i].Translation[0]))
                {
                    UpperandLowercase = true;
                    break;
                }
            }
            Assert.AreEqual(UpperandLowercase,Expected);

        }
    }
}