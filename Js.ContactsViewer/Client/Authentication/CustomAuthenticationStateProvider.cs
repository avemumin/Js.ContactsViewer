using Blazored.SessionStorage;
using Js.ContactsViewer.Client.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Js.ContactsViewer.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSession = await _sessionStorageService
                    .ReadEncryptedItemAsync<UserSession>("UserSession");
                if (userSession == null)
                    return await CatchOrNullUserSession();
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role.Name)
                }, "JwtAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await CatchOrNullUserSession();
            }
        }


        public async Task UpdateAuthenticationState(UserSession? userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)//try to login
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role.Name)
                }));
                userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn);
                await _sessionStorageService.SaveItemEncyptedAsync("UserSession", userSession);
            }
            else //jesli sie wylogowujemy to warto wyczyścic pamięć sesji
            {
                claimsPrincipal = _anonymous;
                await _sessionStorageService.RemoveItemAsync("UserSession");
            }
            //na koniec powiadomić o zmiane stanu atuentykacji
            NotifyAuthenticationStateChanged(Task.FromResult(
                new AuthenticationState(claimsPrincipal)));
        }

        private async Task<AuthenticationState> CatchOrNullUserSession()
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }
}

//Proces autryzacji i autentykacji po stronie klienta wspomagają darmowe
//nugety Microsoft.aspnetcore.components.authorization oraz
//Blazored.SessionStorage se