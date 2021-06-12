using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverHepsiburadaCase
{
    public class AreaSize : IScanningAreaSize
    {
        public virtual int Width { get; private set; }
        public virtual int Height { get; private set; }

        private static readonly char ConstantSeperate = ' '; 

        public AreaSize(string areaSize)
        {
            if (string.IsNullOrEmpty(areaSize))
                throw new Exception("Area can't be null");

            string[] totalSize = areaSize.Split(AreaSize.ConstantSeperate);

            //Has two dimension
            if (totalSize.Length != 2)
                throw new Exception("Only two dimesion");

            this.Width = Convert.ToInt32(totalSize[0]);
            this.Height = Convert.ToInt32(totalSize[1]); 
        } 
    }
}
