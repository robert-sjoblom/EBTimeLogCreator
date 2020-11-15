using System.Net.Http;
using System.Threading.Tasks;

namespace EBTimeLogCreator
{
    public interface IRestService
    {
        Task<HttpResponseMessage> SaveTimeLogAsync(TimeEntry item, string auth_string);
    }
}