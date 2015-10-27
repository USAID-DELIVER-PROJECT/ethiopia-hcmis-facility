using System;
using System.Drawing;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Print
{
	/// <summary>
	/// Represents a Data Grid with advanced options
	/// </summary>
	public class Grid
	{
		
		private Font fontGridFont;
		private Font fontGridHeadersFont;
		
		public Color HeaderBackColor;
		public Color HeaderForeColor;
		public Color LineColor;
		public Color ForeColor;
		public Color BackColor;
		
		private int rows;
		private int columns;
		
		public float Width;
		public float Height;

		public Cell[,] Cells;
		
		public Header[] Headers;

		public Header this[int Column]
		{
			get {return Headers[columns];}
			
		}

		/// <summary>
		/// The Font of the text in the cells
		/// </summary>
		public Font Font
		{
			get {return fontGridFont;}
			set {fontGridFont = value;}
		}

		/// <summary>
		/// The Font of the text in the header cells
		/// </summary>
		public Font HeaderFont
		{
			get {return fontGridHeadersFont;}
			set {fontGridHeadersFont = value;}
		}

		public int Rows
		{
			get {return rows;}
		}

		public int Columns
		{
			get {return columns;}
		}

		/// <summary>
		/// Gets or Sets a Cell
		/// </summary>
		public Cell this[int RowNumber,int ColumnNumber]
		{
			get 
			{
				//check to see if the cell exists
				if (RowNumber>=0 && ColumnNumber>=0 && RowNumber<=Cells.GetUpperBound(0) && ColumnNumber<=Cells.GetUpperBound(1))
				{
					//return found cell
					return Cells[RowNumber,ColumnNumber];
				}
				else
				{
					//error - no cell found
					return null;
					//throw new NoCellException
				}
			}
			set
			{
				//Check the number of Cell to exist
				if (RowNumber>=0 && ColumnNumber>=0 && RowNumber<=Cells.GetUpperBound(0) && ColumnNumber<=Cells.GetUpperBound(1))
				{
					//set value
					Cells[RowNumber,ColumnNumber]=value;
				}
				else
				{
					//throw new NoCellException
				}
			}
		}

		/// <summary>
		/// Set a new value for a cell
		/// </summary>
		public Cell this[Cell cell]
		{
			set {Cells[cell.RowNumber,cell.ColumnNumber]=value;}
		}

		public Grid(DataGrid TheGrid)
		{
			try
			{
				//get the Data in the grid
				DataTable TableGrid = null;

				if (TheGrid.DataSource.GetType()==typeof(DataView))
				{
					DataView ViewGrid = (DataView)TheGrid.DataSource;
					TableGrid = ViewGrid.Table;
					
				}
				else
				{
					TableGrid = (DataTable)TheGrid.DataSource;
				}
				//set number of rows
				rows = TableGrid.DefaultView.Count;
			
				//set number of columns
				//first check if the grid has tablestyle and columnstyle
				
				//check for table styles
				if (TheGrid.TableStyles.Count==0)
				{
					//create table style and column style
					CreateColumnStyles(TheGrid,TableGrid);
				}
				else
				{
					//create column styles if there are none
					if (TheGrid.TableStyles[TableGrid.TableName].GridColumnStyles.Count==0)
						CreateColumnStyles(TheGrid,TableGrid);
				}
			
				//set number of columns
				columns = TheGrid.TableStyles[TableGrid.TableName].GridColumnStyles.Count;

							

				Cells = new Cell[Rows,Columns];

				//Copy Cells
				for (int i=0;i<Rows;i++)
				{
					for (int j=0;j<Columns;j++)
					{
						Cells[i,j] = new Cell(i,j,TheGrid.Font,TheGrid.TableStyles[TableGrid.TableName].GridColumnStyles[j].Alignment,TheGrid.GetCellBounds(i,j),TheGrid[i,j].ToString());
						
					
					}
					Height +=Cells[i,0].Height;
				}

				//init number of columns to headers
				Headers = new Header[Columns];
				SetHeaders(TheGrid,TableGrid);
				
				//define grid colors
				SetColors(TheGrid);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public Grid()
		{
		}

		private void CreateColumnStyles(DataGrid TheGrid,DataTable TableGrid)
		{
			// Define new table style.
			DataGridTableStyle tableStyle = new DataGridTableStyle();
			
			Graphics g = TheGrid.CreateGraphics();

			try
			{
            
				// Clear any existing table styles.
				TheGrid.TableStyles.Clear();
  
				// Use mapping name that is defined in the data source.
				tableStyle.MappingName = TableGrid.TableName;
  
				// Now create the column styles within the table style.
				DataGridTextBoxColumn columnStyle;
				
				
				for (int iCurrCol = 0; iCurrCol < TableGrid.Columns.Count; 
					iCurrCol++)
				{
					DataColumn dataColumn = TableGrid.Columns[iCurrCol];
    
					columnStyle = new DataGridTextBoxColumn();

					
					columnStyle.HeaderText = dataColumn.ColumnName;
					columnStyle.MappingName = dataColumn.ColumnName; 


					
		
					
					columnStyle.TextBox.Width = TheGrid.GetCellBounds(0,iCurrCol).Width;  

					columnStyle.TextBox.Height = (int)g.MeasureString(columnStyle.HeaderText,TheGrid.HeaderFont).Height + 10;

					
					// Add the new column style to the table style.
					tableStyle.GridColumnStyles.Add(columnStyle);
				}    

				
				// Add the new table style to the data grid.
			
				TheGrid.TableStyles.Add(tableStyle);
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				g.Dispose();
			}
			
		}
		private void SetHeaders(DataGrid TheGrid,DataTable TableGrid)
		{
			try
			{
				//Check if there are styles
				if (TheGrid.TableStyles.Count>0)
				{
					if (TheGrid.TableStyles[TableGrid.TableName].GridColumnStyles.Count>0)	 
					{
						for (int i=0;i<=Headers.GetUpperBound(0);i++)
						{
							//Known bug - when there are no rows headers are not displayed properly
							DataGridTextBoxColumn columnStyle = (DataGridTextBoxColumn)TheGrid.TableStyles[TableGrid.TableName].GridColumnStyles[i];
							if (Cells.GetUpperBound(0)>0)
							{
								Headers[i] = new Header(i,TheGrid.HeaderFont,columnStyle.Alignment,new RectangleF(Cells[0,i].Location.X,columnStyle.TextBox.Bounds.Y,Cells[0,i].Location.Width,Cells[0,i].Location.Height),columnStyle.HeaderText);
							}
							else
							{
								Headers[i] = new Header(i,TheGrid.HeaderFont,columnStyle.Alignment,columnStyle.TextBox.Bounds,columnStyle.HeaderText);
							}
							Width += Headers[i].Width;
						}
						Height += Headers[0].Height;

					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void SetColors(DataGrid TheGrid)
		{
			HeaderBackColor = TheGrid.HeaderBackColor;
			HeaderForeColor = TheGrid.HeaderForeColor;
			LineColor = TheGrid.GridLineColor;
			ForeColor = TheGrid.ForeColor;
			BackColor = TheGrid.BackColor;
		}

	}
}
