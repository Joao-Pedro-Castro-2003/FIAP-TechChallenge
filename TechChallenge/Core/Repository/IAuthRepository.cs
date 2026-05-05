using Core.Dto;
using Core.Input;

namespace Core.Repository
{
    public interface IAuthRepository
    {
        string Login(LoginInput input);
    }
}
