using Nest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace FileMoniterningSystem
{
    static class FileWatcherClass
    {
        public static bool Moniter_Status { get; set; }
        public static string PathoftheFile { get; set; }
        public static string EventHappened { get; set; }
        public static string TimeEventHappened { get; set; }
        public static StreamWriter file { get; set; }
        static FileWatcherClass()
        {
            file = File.CreateText(@"C:\Users\mjaffry\Downloads\MyJson\logs.json") ;
            file.Close();
        }
        
        public static void fileWatcher(string filePath)
        {

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = filePath;
           
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.FileName|NotifyFilters.Size;
            watcher.Filter = "*.*";

            // will track changes in sub-folders as well
            watcher.IncludeSubdirectories = true;

            // Add event handlers.  
            watcher.Changed += watcher_Changed;
            watcher.Created += watcher_Created;
            watcher.Deleted += watcher_Deleted;
            watcher.Renamed += watcher_Renamed;
            watcher.Error += Watcher_Error;
            watcher.EnableRaisingEvents = true;
            new System.Threading.AutoResetEvent(false).WaitOne();
            }

        private static void Watcher_Error(object sender, ErrorEventArgs e)
        {
            
        }

        private static void watcher_Renamed(object sender, RenamedEventArgs e)
        {

            try
            {
                PathoftheFile = e.FullPath;
                EventHappened = e.ChangeType.ToString();
                TimeEventHappened = DateTime.Now.ToString();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally { WriteToJson(); }
        }

        private static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                PathoftheFile = e.FullPath;
                EventHappened = e.ChangeType.ToString();
                TimeEventHappened = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
            System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally { WriteToJson(); }
        }

        private static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                PathoftheFile = e.FullPath;
                EventHappened = e.ChangeType.ToString();
                TimeEventHappened = DateTime.Now.ToString();

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                WriteToJson();
            }
        }

        private static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                PathoftheFile = e.FullPath;
                EventHappened = e.ChangeType.ToString();
                TimeEventHappened = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                WriteToJson();
            }
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                PathoftheFile = e.FullPath;
                EventHappened = e.ChangeType.ToString();
                TimeEventHappened = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally 
            {
                WriteToJson();
            }
        }

        private static void WriteToJson()
        {
            using (StreamWriter file = File.AppendText(@"C:\Users\mjaffry\Downloads\MyJson\logs.json"))
            {
                JObject FileMoniteringObject = new JObject(
                new JProperty(PathoftheFile, EventHappened, TimeEventHappened));
                
                //static string JSON Results = JsonConvert.SerializeObject(FileMoniteringObject);
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, FileMoniteringObject);
            }
        }

        
    }
}
