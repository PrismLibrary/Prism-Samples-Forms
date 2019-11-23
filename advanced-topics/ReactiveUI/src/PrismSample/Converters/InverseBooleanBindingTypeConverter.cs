using System;
using ReactiveUI;
using Splat;

namespace PrismSample.Converters
{
    public class InverseBooleanBindingTypeConverter : IBindingTypeConverter
    {
        public int GetAffinityForObjects(Type fromType, Type toType) =>
            fromType == typeof(bool) ? 100 : 0;

        public bool TryConvert(object @from, Type toType, object conversionHint, out object result)
        {
            try
            {
                var truth = (bool) @from;
                result = !truth;
            }
            catch (Exception ex)
            {
                this.Log().Warn("Couldn't convert object to type: " + toType, ex);
                result = null;
                return false;
            }

            return true;
        }
    }
}