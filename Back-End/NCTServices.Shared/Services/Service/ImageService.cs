using NCTServices.Shared.Services.Interface;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace NCTServices.Shared.Services.Service
{
    public class ImageService : IImageService
    {
        public byte[] FormatSaveImage(byte[] imagebyte)
        {
            using (var image = Image.Load(imagebyte))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(800, 600),
                    Mode = ResizeMode.Max
                }));

                using (var ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms, new JpegEncoder { Quality = 75 });
                    return ms.ToArray();
                }
            }
        }

        public byte[] GetImage(byte[] imageId)
        {
            using (var image = Image.Load(imageId))
            {
                using (var ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}
