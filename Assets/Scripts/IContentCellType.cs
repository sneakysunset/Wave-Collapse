using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IContentCellType
{
    public void CreateContent(int row, int column);

    public void DeleteContent();

}
