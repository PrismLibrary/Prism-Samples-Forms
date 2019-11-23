using System;
using NuGet.Versioning;
using ReactiveUI;
using Splat;

namespace PrismSample.Converters
{
    public class VersionToStringConverter : IBindingTypeConverter
    {
        public int GetAffinityForObjects(Type fromType, Type toType) =>
            fromType == typeof(NuGetVersion) ? 100 : 0;

        public bool TryConvert(object @from, Type toType, object conversionHint, out object result)
        {
            try
            {
                var version = (NuGetVersion) @from;
                result = $"{version.Major}.{version.Minor}.{version.Patch}";
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