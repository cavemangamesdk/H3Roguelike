using SixLabors.ImageSharp.Advanced;

namespace MooseEngine.Extensions.SixLabors.ImageSharp;

public struct ImageData
{
    public byte[] Pixels { get; set; }
    public int BitPerPixel { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}

public interface IImageLoader
{
    ImageData LoadImage(string filepath, bool flipVertical = false);
}

internal sealed class ImageLoader : IImageLoader
{
    public ImageData LoadImage(string filepath, bool flipVertical)
    {
        Image<Rgba32> image = Image.Load<Rgba32>(filepath);
        image.Mutate(x => x.Flip(flipVertical ? FlipMode.Vertical : FlipMode.Horizontal));

        List<byte> pixels = new(image.Width * image.Height);
        for (int y = 0; y < image.Height; y++)
        {
            var row = image.DangerousGetPixelRowMemory(y);
            //var row = image.GetPixelRowSpan(y);
            for (int x = 0; x < image.Width; x++)
            {
                pixels.Add(row.Span[x].R);
                pixels.Add(row.Span[x].G);
                pixels.Add(row.Span[x].B);
                pixels.Add(row.Span[x].A);
            }
        }

        image.Dispose();

        return new ImageData
        {
            Pixels = pixels.ToArray(),
            BitPerPixel = image.PixelType.BitsPerPixel,
            Height = image.Height,
            Width = image.Width,
        };
    }
}