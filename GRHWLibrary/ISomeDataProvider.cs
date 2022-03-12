using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRHWLibrary
{
    public interface ISomeDataProvider
    {
        List<SomeData> GetData(ISomeFileReader fileReader, char delimiter);

    }
}
