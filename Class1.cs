using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public enum MeasureType { mm, ga, ap, des };

    public class Square
    {
        private double value;
        private MeasureType type;
        public Square(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.mm:
                    typeVerbose = "кв.м";
                    break;
                case MeasureType.ga:
                    typeVerbose = "га";
                    break;
                case MeasureType.ap:
                    typeVerbose = "ап";
                    break;
                case MeasureType.des:
                    typeVerbose = "десятин";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }
    }
}
