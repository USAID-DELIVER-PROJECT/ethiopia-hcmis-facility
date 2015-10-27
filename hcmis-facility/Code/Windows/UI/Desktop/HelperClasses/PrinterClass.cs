using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Data;

namespace Print
{
	/// <summary>
	/// Summary description for PrinterClass.
	/// </summary>
	public class PrinterClass
	{
		//clone of Datagrid
		private Grid PrintGrid;
		
		//printdocument for initial printer settings
		private PrintDocument PrintDoc;

		//pageSettings
		private int pageWidth;
		private int pageHeight;
		private bool pageLandscape;
		
		//pageMargins
		private int pageMarginRight;
		private int pageMarginLeft;
		private int pageMarginTop;
		private int pageMarginBottom;

		//defines whether the grid is ordered right to left
		private bool bRightToLeft;
		
		//Current Top
		private float CurrentY = 0;

		//Current Left
		private float CurrentX = 0;

		//CurrentRow to print
		private int CurrentRow = 0;

		//Page Counter
		public int PageCounter=0;

		/// <summary>
		/// Constructor Class
		/// </summary>
		/// <param name="pdocument"></param>
		/// <param name="dgrid"></param>
		public PrinterClass(PrintDocument pdocument,DataGrid dgrid)
		{
			PrintGrid = new Grid(dgrid);
			PrintDoc = pdocument;

			//The grid columns are right to left
			bRightToLeft = dgrid.RightToLeft==RightToLeft.Yes;

			//init page settings
			pageWidth = pdocument.DefaultPageSettings.PaperSize.Width;
			pageHeight = pdocument.DefaultPageSettings.PaperSize.Height;
			pageLandscape = pdocument.DefaultPageSettings.Landscape;

			//init margin settings
			pageMarginLeft = pdocument.DefaultPageSettings.Margins.Left;
			pageMarginTop = pdocument.DefaultPageSettings.Margins.Top;
			pageMarginRight = pdocument.DefaultPageSettings.Margins.Right;
			pageMarginBottom = pdocument.DefaultPageSettings.Margins.Bottom;

			//init CurrentX and CurrentY
			CurrentY = pageMarginTop;
			CurrentX =  pageMarginLeft;
			

		}

		public bool Print(Graphics g,ref float currentX,ref float currentY)
		{
			//use predefined area
			CurrentX = currentX;
			CurrentY = currentY;
			

			PrintHeaders(g);
			bool Morepages = PrintDataGrid(g);

			currentY = CurrentY;
			currentX = CurrentX;

			return Morepages;

			
		}

		public bool Print(Graphics g)
		{
			CurrentX = pageMarginLeft;
			CurrentY = pageMarginTop;

			PrintHeaders(g);
			return PrintDataGrid(g);
		}

		/// <summary>
		/// Print the Grid Headers
		/// </summary>
		/// <param name="g"></param>
		private void PrintHeaders(Graphics g)
		{
			StringFormat sf = new StringFormat();

			//if we want to print the grid right to left
			if (bRightToLeft)
			{
				CurrentX = pageWidth - pageMarginRight;
				sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
			}
			else
			{
				CurrentX = pageMarginLeft;
			}

			for (int i=0;i<PrintGrid.Columns;i++)
			{
				//set header alignment
				switch (((Header)PrintGrid.Headers.GetValue(i)).Alignment)
				{
						//left
					case HorizontalAlignment.Left:
						sf.Alignment = StringAlignment.Near;
						break;

						//right
					case HorizontalAlignment.Center:
						sf.Alignment = StringAlignment.Center;
						break;

						//right
					case HorizontalAlignment.Right:
						sf.Alignment = StringAlignment.Far;
						break;
				}

				//advance X according to order
				if (bRightToLeft)
				{
						
					//draw the cell bounds (lines) and back color
					g.FillRectangle(new SolidBrush(PrintGrid.HeaderBackColor),CurrentX - PrintGrid.Headers[i].Width,CurrentY,PrintGrid.Headers[i].Width,PrintGrid.Headers[i].Location.Height);
					g.DrawRectangle(new Pen(PrintGrid.LineColor),CurrentX - PrintGrid.Headers[i].Width,CurrentY,PrintGrid.Headers[i].Width,PrintGrid.Headers[i].Location.Height);
					
					
					//draw the cell text
					g.DrawString(PrintGrid.Headers[i].Text,PrintGrid.Headers[i].Font,new SolidBrush(PrintGrid.HeaderForeColor),new RectangleF(CurrentX - PrintGrid.Headers[i].Width,CurrentY,PrintGrid.Headers[i].Width,PrintGrid.Headers[i].Height),sf);
			
					//next cell
					CurrentX -=PrintGrid.Headers[i].Width;
					
				}
				else
				{
						
					//draw the cell bounds (lines) and back color
					g.FillRectangle(new SolidBrush(PrintGrid.HeaderBackColor),CurrentX,CurrentY,PrintGrid.Headers[i].Width,PrintGrid.Headers[i].Location.Height);
					g.DrawRectangle(new Pen(PrintGrid.LineColor),CurrentX,CurrentY,PrintGrid.Headers[i].Width,PrintGrid.Headers[i].Location.Height);
					
					
					//draw the cell text
					g.DrawString(PrintGrid.Headers[i].Text,PrintGrid.Headers[i].Font,new SolidBrush(PrintGrid.HeaderForeColor),new RectangleF(CurrentX,CurrentY,PrintGrid.Headers[i].Width,PrintGrid.Headers[i].Height),sf);
					
					//next cell
					CurrentX +=PrintGrid.Headers[i].Width;
				}
					
					
			}

			//reset to beginning
			if (bRightToLeft)
			{
				//right align
				CurrentX = pageWidth - pageMarginRight;
			}
			else
			{
				//left align
				CurrentX = pageMarginLeft;
			}

			//advance to next row
			CurrentY = CurrentY + ((Header)(PrintGrid.Headers.GetValue(0))).Location.Height;
			 
		}

		private bool PrintDataGrid(Graphics g)
		{	
			StringFormat sf = new StringFormat();
			PageCounter++;
			
			//if we want to print the grid right to left
			if (bRightToLeft)
			{
				CurrentX = pageWidth - pageMarginRight;
				sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
			}
			else
			{
				CurrentX = pageMarginLeft;
			}

			for (int i=CurrentRow;i<PrintGrid.Rows;i++)
			{
				for (int j=0;j<PrintGrid.Columns;j++)
				{
					//set cell alignment
					switch (PrintGrid[i,j].Alignment)
					{
							//left
						case HorizontalAlignment.Left:
							sf.Alignment = StringAlignment.Near;
							break;

							//center
						case HorizontalAlignment.Center:
							sf.Alignment = StringAlignment.Center;
							break;

							//right
						case HorizontalAlignment.Right:
							sf.Alignment = StringAlignment.Far;
							break;
					}
					
					//advance X according to order
					if (bRightToLeft)
					{
						
						//draw the cell bounds (lines) and back color
						g.FillRectangle(new SolidBrush(PrintGrid.BackColor),CurrentX - PrintGrid[i,j].Width,CurrentY,PrintGrid[i,j].Width,PrintGrid[i,j].Height);
						g.DrawRectangle(new Pen(PrintGrid.LineColor),CurrentX - PrintGrid[i,j].Width,CurrentY,PrintGrid[i,j].Width,PrintGrid[i,j].Height);
						
					
						//draw the cell text
						g.DrawString(PrintGrid[i,j].Text,PrintGrid[i,j].Font,new SolidBrush(PrintGrid.ForeColor),new RectangleF(CurrentX - PrintGrid[i,j].Width,CurrentY,PrintGrid[i,j].Width,PrintGrid[i,j].Height),sf);

						//next cell
						CurrentX -=PrintGrid[i,j].Width;
					
					}
					else
					{
						
						//draw the cell bounds (lines) and back color
						g.FillRectangle(new SolidBrush(PrintGrid.BackColor) ,CurrentX,CurrentY,PrintGrid[i,j].Width,PrintGrid[i,j].Height);
						g.DrawRectangle(new Pen(PrintGrid.LineColor) ,CurrentX,CurrentY,PrintGrid[i,j].Width,PrintGrid[i,j].Height);
						
					
						//draw the cell text
						//Draw text by alignment
						
							
						g.DrawString(PrintGrid[i,j].Text,PrintGrid[i,j].Font,new SolidBrush(PrintGrid.ForeColor),new RectangleF(CurrentX,CurrentY,PrintGrid[i,j].Width,PrintGrid[i,j].Height),sf);
							
						//next cell
						CurrentX +=PrintGrid[i,j].Width;
					}
					
					
				}

				//reset to beginning
				if (bRightToLeft)
				{
					//right align
					CurrentX = pageWidth - pageMarginRight;
				}
				else
				{
					//left align
					CurrentX = pageMarginLeft;
				}
				
				//advance to next row
                CurrentY = CurrentY + PrintGrid[i,0].Height;
				CurrentRow++;
				//if we are beyond the page margin (bottom/side) then we need another page,
				//return true
				
				//if portrait is selected
				if((CurrentY > pageHeight - 
					pageMarginBottom)&&(!pageLandscape))
					{
					return true;
					}

				//if landscape is selected
				if((CurrentY > pageWidth - 
					pageMarginRight)&&(pageLandscape))
					{
					return true;
					}
				
			}
			CurrentRow = 0;
			return false;
			
		}

	}
}
