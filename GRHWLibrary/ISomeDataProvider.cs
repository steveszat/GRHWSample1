using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRHWLibrary
{
    public interface ISomeDataProvider<T>
    {
        List<T> GetData(ISomeFileHandler fileReader, char delimiter);

    }
}
