using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesIntersection
{
	internal class Circle
	{
		public Point Center { get; set; }

		public double Radius { get; set; }

		public Circle(Point center, double radius)
		{
			Center = center;
			Radius = radius;
		}
	}
}
