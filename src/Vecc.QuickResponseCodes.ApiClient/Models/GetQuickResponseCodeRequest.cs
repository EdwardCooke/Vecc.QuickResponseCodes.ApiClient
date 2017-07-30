namespace Vecc.QuickResponseCodes.ApiClient.Models
{
    public class GetQuickResponseCodeRequest
    {
        public GetQuickResponseCodeRequest()
        {
        }

        public GetQuickResponseCodeRequest(byte[] data,
                                           Abstractions.ErrorToleranceLevel errorToleranceLevel,
                                           Abstractions.CodeImageFormat imageFormat,
                                           int? dimensions,
                                           int? border,
                                           Abstractions.Color backgroundColor,
                                           Abstractions.Color foregroundColor)
        {
            this.BackgroundColor = backgroundColor == null ? null : new Color(backgroundColor);
            this.Border = border;
            this.Data = data;
            this.Dimensions = dimensions;
            this.ErrorToleranceLevel = (ErrorToleranceLevel)errorToleranceLevel;
            this.ImageFormat = (CodeImageFormat)imageFormat;
            this.ForegroundColor = foregroundColor == null ? null : new Color(foregroundColor);
        }

        public Color BackgroundColor { get; set; }
        public int? Border { get; set; }
        public byte[] Data { get; set; }
        public int? Dimensions { get; set; }
        public ErrorToleranceLevel ErrorToleranceLevel { get; set; }
        public Color ForegroundColor { get; set; }
        public CodeImageFormat ImageFormat { get; set; }
    }
}
