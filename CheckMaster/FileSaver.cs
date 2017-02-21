using CheckMaster.FileDialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckMaster
{
    class FileSaver
    {
        private static string PATH = Application.StartupPath;
        private static string SUFFIX = ".modules";

        /// <summary>
        /// Save a ModuleManager to the original path
        /// </summary>
        /// <param name="moduleManager"></param>
        public static void save(ModuleManager moduleManager)
        {            Serializer.SerializeObject<ModuleManager>(moduleManager, PATH + @"\" + Properties.Settings.Default["modulemanager"].ToString());
        }

        /// <summary>
        /// Open a form to save a ModuleManager
        /// </summary>
        /// <param name="moduleManager"></param>
        public static void saveDialog(ModuleManager moduleManager)
        {
            SaveFileForm saveFileForm = new SaveFileForm(PATH, SUFFIX);
            saveFileForm.TopMost = true;
            saveFileForm.ShowDialog();

            if (saveFileForm.save)
            {
                Properties.Settings.Default["modulemanager"] = saveFileForm.file + SUFFIX;

                FileSaver.save(moduleManager);
            }
        }

        /// <summary>
        /// Load with a dialog and return a file with particular suffix.
        /// </summary>
        /// <returns></returns>
        public static ModuleManager load()
        {
            Console.WriteLine(Properties.Settings.Default["modulemanager"].ToString());
            Console.WriteLine(File.Exists(Properties.Settings.Default["modulemanager"].ToString()));
            return Serializer.DeSerializeObject<ModuleManager>(File.Open(PATH + @"\" + Properties.Settings.Default["modulemanager"].ToString(), FileMode.Open));
        }

        /// <summary>
        /// Load with a dialog and return a file with particular suffix.
        /// </summary>
        /// <returns></returns>
        public static ModuleManager loadDialog()
        {
            Console.WriteLine(PATH);
            LoadFileForm loadFileForm = new LoadFileForm(PATH, SUFFIX);
            loadFileForm.TopMost = true;
            loadFileForm.ShowDialog();

            if(loadFileForm.load)
                Properties.Settings.Default["modulemanager"] = loadFileForm.file;

            return FileSaver.load();
        }
    }
}
