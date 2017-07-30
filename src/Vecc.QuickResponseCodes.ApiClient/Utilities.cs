using System;
using Vecc.QuickResponseCodes.Abstractions;

namespace Vecc.QuickResponseCodes.ApiClient
{
    public class Utilities : IUtilities
    {
        public bool DataFitsWithErrorCorrection(byte[] data, ErrorToleranceLevel errorTolerance)
        {
            return data.Length <= this.GetMaxDataLength(errorTolerance);
        }

        public int GetMaxDataLength(ErrorToleranceLevel errorTolerance)
        {
            switch (errorTolerance)
            {
                case ErrorToleranceLevel.High:
                    return 1273;
                case ErrorToleranceLevel.Low:
                    return 2331;
                case ErrorToleranceLevel.Medium:
                    return 1663;
                case ErrorToleranceLevel.VeryLow:
                    return 2953;
                default:
                    throw new ArgumentOutOfRangeException(nameof(errorTolerance));
            }
        }
    }
}
