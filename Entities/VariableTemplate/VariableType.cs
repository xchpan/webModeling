using System;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class VariableType : TemplateBase
    {
        private double min;
        private double max;

        public VariableType(Guid id) : base(id)
        {
            min = double.MinValue;
            max = double.MaxValue;
        }

        public double MinValue
        {
            get { return min; }
            set
            {
                if (value > max)
                {
                    throw new ArgumentException("min is larger than max");
                }
                min = value;
            }
        }

        public double MaxVallue
        {
            get
            {
                return max;
            }
            set
            {
                if (value < min)
                {
                    throw new ArgumentException("max is less than min");
                }
                max = value;
            }
        }

        public UnitCollection Units { get; set; }
    }
}
