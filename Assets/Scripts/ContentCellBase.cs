using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContentCellBase : IContentCellType
{
    public virtual void CreateContent(int row, int column)
    {
    }

    public virtual void DeleteContent()
    {
    }
}
