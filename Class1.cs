using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public enum MeasureType { mm, ga, ar, des };

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
                case MeasureType.ar:
                    typeVerbose = "ар";
                    break;
                case MeasureType.des:
                    typeVerbose = "десятин";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }
        public static Square operator +(Square instance, double number)
        {
            return new Square(instance.value + number, instance.type);
        }
        public static Square operator +(double number, Square instance)
        {
            return instance + number;
        }
        public static Square operator -(Square instance, double number)
        {
            return new Square(instance.value - number, instance.type);
        }
        public static Square operator -(double number, Square instance)
        {
            return instance - number;
        }
        public static Square operator *(Square instance, double number)
        {
            return new Square(instance.value * number, instance.type);
        }
        public static Square operator *(double number, Square instance)
        {
            return instance * number;
        }
        public Square To(MeasureType newType)
        {
            var newValue = this.value;
            
            if (this.type == MeasureType.mm)
            {
                
                switch (newType)
                {
                    
                    case MeasureType.mm:
                        newValue = this.value;
                        break;
                    
                    case MeasureType.ga:
                        newValue = this.value / 10000;
                        break;
                    
                    case MeasureType.ar:
                        newValue = this.value / 100;
                        break;
                    
                    case MeasureType.des:
                        newValue = this.value / 10925.4;
                        break;
                }
            }
            else if (newType == MeasureType.mm)
            {
                switch (this.type)
                {
                    case MeasureType.mm:
                        newValue = this.value;
                        break;
                    case MeasureType.ga:
                        newValue = this.value * 10000;
                        break;
                    case MeasureType.ar:
                        newValue = this.value * 100;
                        break;
                    case MeasureType.des:
                        newValue = this.value * 10925.4;
                        break;
                }
            }
            else
            {
                newValue = this.To(MeasureType.mm).To(newType).value;
            }
            return new Square(newValue, newType);
        }
    }
}
