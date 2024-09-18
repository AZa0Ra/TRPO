using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_lab1
{
    internal class ComplexNum
    {

        public ComplexNum() { }
        public ComplexNum(double realNum, double imagineNum) 
        {
            RealNum = realNum;
            ImagineNum = imagineNum;
        }

        public double RealNum { get; set; }

        public double ImagineNum { get; set;}


        public override string ToString()
        {
            return $"{RealNum}.{ImagineNum}";
        }
    }
}
