namespace Framework.Security
{
    public interface IAuthorizationService
    {
        void Authorize(params int[] operations);
    }
}
