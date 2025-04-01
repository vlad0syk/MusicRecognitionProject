using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicRecognitionProject.Models;

namespace MusicRecognitionProject.Dao
{
    public interface IMusicResultDao
    {
        List<MusicResult> GetLast();
        List<MusicResult> Read();
        void Add(MusicResult result);
        void Save();
    }
}
