using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanglePosition
{
	internal class Rectangle
	{
		public Point TopLeftCorner { get; set; }

		public int Width { get; set; }
		public int Height { get; set; }

		public Point BottomRightCorner =>
			new()
			{
				X = TopLeftCorner.X + Width,
				Y = TopLeftCorner.Y + Height
			};

		public Rectangle(Point topLeftCorner, int width, int height)
		{
			TopLeftCorner = topLeftCorner;
			Width = width;
			Height = height;
		}
	}
}
