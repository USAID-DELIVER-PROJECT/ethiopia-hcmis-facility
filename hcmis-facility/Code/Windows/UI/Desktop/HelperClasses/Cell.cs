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
	/// Represents a single cell in a datagrid
	/// </summary>
	public class Cell
	{
		private RectangleF rectLocation;

		private float fCellHeight;
		private float fCellWidth;
		private float fCellX;
		private float fCellY;

		private Font fontCellFont;
		private HorizontalAlignment haAlignment;
		private string sText;

		private int iColumnNumber;

		private int iRowNumber;

		/// <summary>
		/// The Font of the text in the cell
		/// </summary>
		public string Text
		{
			get {return sText;}
			set {sText = value;}
		}

		/// <summary>
		/// The Font of the text in the cell
		/// </summary>
		public Font Font
		{
			get {return fontCellFont;}
			set {fontCellFont = value;}
		}

		/// <summary>
		/// The Location of the cell
		/// </summary>
		public RectangleF Location
		{
			get {return rectLocation;}
		}


		/// <summary>
		/// Set The location of the Cell
		/// </summary>
		protected RectangleF RectLocation
		{
			set 
			{
				rectLocation = value;
				fCellWidth = value.Width;
				fCellHeight = value.Height;
				fCellX = value.X;
				fCellY = value.Y;

			}
		}

		/// <summary>
		/// Get the Height of the cell
		/// </summary>
		public float Height
		{
			get {return fCellHeight;}
		}

		/// <summary>
		/// Get the Height of the cell
		/// </summary>
		public float Width
		{
			get {return fCellWidth;}
		}

		/// <summary>
		/// Get the Height of the cell
		/// </summary>
		public float X
		{
			get {return fCellX;}
		}

		/// <summary>
		/// Get the Height of the cell
		/// </summary>
		public float Y
		{
			get {return fCellY;}
		}

		/// <summary>
		/// The Column number of the Cell
		/// </summary>
		public virtual int ColumnNumber
		{
			get {return iColumnNumber;}
		}

		/// <summary>
		/// The Row number of the cell
		/// </summary>
		public int RowNumber
		{
			get {return iRowNumber;}
		}

		/// <summary>
		/// The Horizonal Alignment cell
		/// </summary>
		public HorizontalAlignment Alignment
		{
			get {return haAlignment;}
			set {haAlignment = value;}
		}

		public Cell()
		{
			
		}

		/// <summary>
		/// Create New Cell
		/// </summary>
		/// <param name="RowNumber"></param>
		/// <param name="ColumnNumber"></param>
		/// <param name="cellfont"></param>
		/// <param name="align"></param>
		/// <param name="location"></param>
		/// <param name="text"></param>
		public Cell(int RowNumber,int ColumnNumber,Font cellfont,HorizontalAlignment align,RectangleF location,string text)
		{
			iRowNumber = RowNumber;
			iColumnNumber = ColumnNumber;
			fontCellFont = cellfont;
			haAlignment = align;
			RectLocation = location;
			sText = text;

		}

		/// <summary>
		/// Create new cell with default Text
		/// </summary>
		/// <param name="RowNumber"></param>
		/// <param name="ColumnNumber"></param>
		/// <param name="cellfont"></param>
		/// <param name="align"></param>
		/// <param name="location"></param>
		public Cell(int RowNumber,int ColumnNumber,Font cellfont,HorizontalAlignment align,RectangleF location)
		{
			iRowNumber = RowNumber;
			iColumnNumber = ColumnNumber;
			fontCellFont = cellfont;
			haAlignment = align;
			RectLocation = location;
			sText = "";
			
		}

		/// <summary>
		/// Create new cell with default Text and alignment
		/// </summary>
		/// <param name="RowNumber"></param>
		/// <param name="ColumnNumber"></param>
		/// <param name="cellfont"></param>
		/// <param name="location"></param>
		public Cell(int RowNumber,int ColumnNumber,Font cellfont,RectangleF location)
		{
			iRowNumber = RowNumber;
			iColumnNumber = ColumnNumber;
			fontCellFont = cellfont;
			haAlignment = HorizontalAlignment.Left;
			RectLocation = location;
			sText = "";

		}

		/// <summary>
		/// Create new cell with default alignment
		/// </summary>
		/// <param name="RowNumber"></param>
		/// <param name="ColumnNumber"></param>
		/// <param name="cellfont"></param>
		/// <param name="location"></param>
		public Cell(int RowNumber,int ColumnNumber,Font cellfont,RectangleF location,string text)
		{
			iRowNumber = RowNumber;
			iColumnNumber = ColumnNumber;
			fontCellFont = cellfont;
			haAlignment = HorizontalAlignment.Left;
			RectLocation = location;
			sText = text;
			
			

		}
	}
}
