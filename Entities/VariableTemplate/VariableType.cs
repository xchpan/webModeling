using System;

namespace xpan.plantDesign.Domain.SharedLibraries.VariableTemplate
{
    public class VariableType : TemplateBase
    {
        private double min;
        private double max;
        private double defaultValue;

        public VariableType(Guid id) : base(id)
        {
            min = double.MinValue;
            max = double.MaxValue;
            defaultValue = 0;
        }

        public double MinValue
        {
            get { return min; }
        }

        public double MaxVallue
        {
            get
            {
                return max;
            }
        }

        public double DefaultValue
        {
            get { return defaultValue; }
        }

        public void SetMinMaxDefaultValue(double min, double max, double defaultValue)
        {
            if (min <= defaultValue && defaultValue <= max)
            {
                this.min = min;
                this.max = max;
                this.defaultValue = defaultValue;
            }
            else
            {
                throw new ArgumentException("Min must be no greater than default value, and default value must be no greater than max.");
            }
        }

        public UnitCollection Units { get; set; }
    }
}
