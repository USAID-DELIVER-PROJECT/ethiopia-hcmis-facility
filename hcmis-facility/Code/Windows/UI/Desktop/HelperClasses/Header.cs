using System;
using System.Drawing;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Print
{
	/// <summary>
	/// Represents a column in a datagrid
	/// </summary>
	public class Header : Cell
	{
		private int iColumnNumber;

		public override int ColumnNumber
		{
			get {return iColumnNumber;}
		}

		/// <summary>
		/// Create New Header
		/// </summary>
		/// <param name="RowNumber"></param>
		/// <param name="ColumnNumber"></param>
		/// <param name="cellfont"></param>
		/// <param name="align"></param>
		/// <param name="location"></param>
		/// <param name="text"></param>
		public Header(int ColumnNumber,Font Headerfont,HorizontalAlignment align,RectangleF location,string text)
		{
			iColumnNumber = ColumnNumber;
			Font = Headerfont;
			Alignment = align;
			RectLocation  = location;
			Text = text;

		}

		/// <summary>
		/// Create New Header with default alignment
		/// </summary>
		/// <param name="RowNumber"></param>
		/// <param name="ColumnNumber"></param>
		/// <param name="cellfont"></param>
		/// <param name="align"></param>
		/// <param name="location"></param>
		/// <param name="text"></param>
		public Header(int ColumnNumber,Font Headerfont,RectangleF location,string text)
		{
			iColumnNumber = ColumnNumber;
			Font = Headerfont;
			Alignment = HorizontalAlignment.Left;
			RectLocation  = location;
			Text = text;

		}

		
	}
}
