#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Klaus Potzesny (mailto:Klaus.Potzesny@PdfSharpCore.com)
//
// Copyright (c) 2001-2009 empira Software GmbH, Cologne (Germany)
//
// http://www.PdfSharpCore.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.DocumentObjectModel.Visitors;
using PdfSharpCore.Drawing;

namespace MigraDocCore.Rendering
{
  /// <summary>
  /// Formatting information for tables.
  /// </summary>
  public class TableFormatInfo : FormatInfo
  {
    public TableFormatInfo()
    {
    }

    public override bool EndingIsComplete
    {
      get { return this.isEnding; }
    }


    public override bool StartingIsComplete
    {
      get { return !this.IsEmpty && this.startRow > this.lastHeaderRow; }
    }

    public override bool IsComplete
    {
      get { return false; }
    }

    public override bool IsEmpty
    {
      get { return this.startRow < 0; }
    }

    public override bool IsEnding
    {
      get { return this.isEnding; }
    }
    public bool isEnding;

    public override bool IsStarting
    {
      get
      {
        return this.startRow == this.lastHeaderRow + 1;
      }
    }

    public int startColumn = -1;
    public int endColumn = -1;

    public int startRow = -1;
    public int endRow = -1;

    public int lastHeaderRow = -1;
    public SortedList<Cell, FormattedCell> formattedCells;
    public MergedCellList mergedCells;
    public SortedList<int, XUnit> bottomBorderMap;
    public SortedList<int, int> connectedRowsMap;
  }
}
