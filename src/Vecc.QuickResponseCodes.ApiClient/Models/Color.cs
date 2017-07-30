namespace Vecc.QuickResponseCodes.ApiClient.Models
{
    public class Color
    {
        public Color(Abstractions.Color color)
        {
            if (color == null)
            {
                return;
            }

            this.Red = color.Red;
            this.Green = color.Green;
            this.Blue = color.Blue;
            this.Alpha = color.Alpha;
        }

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }
    }
}
