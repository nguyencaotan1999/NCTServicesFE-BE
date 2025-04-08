using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTServices.Shared.Services.Interface
{
    public interface IImageService
    {
        byte[] FormatSaveImage(byte[] imagebyte);
        byte[] GetImage(byte[] imageId);
    }
}
