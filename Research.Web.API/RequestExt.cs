
namespace Research.Web
{
    public static class RequestExt
    {
        public static int CurrentAccountAsIntGet(this DevReactor.Toolbox.API.Requests.Request request)
        {
            return request.AccountIdT<int>();
        }
    }
}