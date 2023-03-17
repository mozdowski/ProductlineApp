using System.Security.Principal;

namespace ProductlineApp.Application.Common.Security;

public interface IAuthorizationManager
{
    public IIdentity Identity { get; set; }
}
