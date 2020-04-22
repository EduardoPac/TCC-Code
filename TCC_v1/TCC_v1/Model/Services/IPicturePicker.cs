using System.IO;
using System.Threading.Tasks;

namespace TCC_v1.Model.Services
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
