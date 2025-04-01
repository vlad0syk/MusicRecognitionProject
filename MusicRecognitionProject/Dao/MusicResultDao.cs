using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MusicRecognitionProject.Models;
using MusicRecognitionProject.Utils;
using Newtonsoft.Json;

namespace MusicRecognitionProject.Dao
{
    public class MusicResultDao : IMusicResultDao
    {
        private static List<MusicResult> _results = new List<MusicResult>();
        public List<MusicResult> GetLast()
        {
            return _results.Distinct().TakeLast(11).ToList();
        }

        public List<MusicResult> Read()
        {
            try
            {
                _results = JsonConvert.DeserializeObject<List<MusicResult>>(File.ReadAllText("recentTracks.db"));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex);
            }

            return _results;
        }

        public void Add(MusicResult result)
        {
            _results.Add(result);
            Save();
        }
        public void Save()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_results, Formatting.Indented);
                File.WriteAllText("recentTracks.db", json);
            }
            catch(Exception ex)
            {
                Logger.LogInfo(ex);
            }
        }
    }
}
