using Vecc.QuickResponseCodes.Abstractions;

namespace Vecc.QuickResponseCodes.ApiClient
{
    public interface IUtilities
    {
        bool DataFitsWithErrorCorrection(byte[] data, ErrorToleranceLevel errorTolerance);
    }
}
