using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Measurements
    {
        public decimal Length;
        public decimal Height;
        public decimal Width;

        public Measurements(MeasurementsDTO sizeDTO)
        {
            Length = sizeDTO.Length;
            Height = sizeDTO.Height;
            Width = sizeDTO.Width;
        }

        public Measurements(decimal width, decimal length, decimal height)
        {
            Length = length;
            Height = height;
            Width = width;
        }
    }
}
