using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIforFTP
{
    public interface IManagerElement
    {
        string ImagePath { get; }

        string ElementName { get; set; }
    }
}
