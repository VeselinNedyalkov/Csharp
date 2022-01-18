using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;
        private const int MinValue = 0;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        private double Lenght 
        {
            get
            {
                return lenght;
            }
            set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                lenght = value;
            }
        }
        private double Width 
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        private double Height 
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");

                }
                height = value;
            }
        }

        public double SurfaceArea()
        {
           return (2 * lenght * width) + (2 * lenght * height) + (2 * height * width);
        }

        public double LateralSurfaceArea()
        {
            return  (2 * lenght * height) + (2 * width * height);
        }

        public double Volume()
        {
            return lenght * width * height;
        }
    }
}
