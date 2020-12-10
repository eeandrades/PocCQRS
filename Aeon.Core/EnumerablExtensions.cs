using System.Threading.Tasks;

namespace Aeon
{
    public static class EnumerablExtensions
    {
        async public static Task<T> ToTask<T>(this T t)
        {
            return await Task<T>.Run(() => t);
        }
    }
}
