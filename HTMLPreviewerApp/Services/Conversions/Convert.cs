using System.Text;

namespace HTMLPreviewerApp.Services.Conversions
{
    public class Convert : IConvert
    {
        public decimal ConvertBytesToMegabytes(string text)
            => (decimal)Encoding.Unicode.GetByteCount(text) / 1048576;
    }
}
