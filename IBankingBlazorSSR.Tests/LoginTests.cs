using Bunit;
using IBankingBlazorSSR.Application.Implementation;
using IBankingBlazorSSR.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace IBankingBlazorSSR.Tests;

public class LoginTests : TestContext
{
    [Fact]
    public async Task LoginUserAsync_ValidCredentials_ReturnsSuccess()
    {
        // Arrange
        // Vytvoření mock objektu pro IUserStore<ApplicationUser>
        var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
        // Vytvoření instance UserManager<ApplicationUser> s použitím IUserStore mock objektu
        var userManager =
            new UserManager<ApplicationUser>(userStoreMock.Object, null, null, null, null, null, null, null, null);

        // Vytvoření mock objektu pro SignInManager<ApplicationUser>
        var signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
            // Předání UserManageru a dalších závislostí
            userManager,
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object,
            new Mock<IUserConfirmation<ApplicationUser>>().Object
        );

        // Nastavení chování metody PasswordSignInAsync na úspěšné přihlášení
        signInManagerMock.Setup(x => x.PasswordSignInAsync("april", "april123", false, false))
            .ReturnsAsync(SignInResult.Success);

        // Vytvoření instance LoginService s použitím SignInManager mock objektu
        var loginService = new LoginService(signInManagerMock.Object);

        // Act
        // Volání metody LoginUserAsync s konkrétními přihlašovacími údaji
        var result = await loginService.LoginUserAsync("april", "april123");

        // Assert
        // Ověření, že přihlášení bylo úspěšné a ErrorMessage je prázdný řetězec
        Assert.True(result.Success);
        Assert.Equal(string.Empty, result.ErrorMessage);
    }

    [Fact]
    public async Task LoginUserAsync_InvalidCredentials_ReturnsFailureWithErrorMessage()
    {
        // Arrange
        // Vytvoření mock objektu pro IUserStore<ApplicationUser>
        var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
        // Vytvoření instance UserManager<ApplicationUser> s použitím IUserStore mock objektu
        var userManager =
            new UserManager<ApplicationUser>(userStoreMock.Object, null, null, null, null, null, null, null, null);

        // Vytvoření mock objektu pro SignInManager<ApplicationUser>
        var signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
            // Předání UserManageru a dalších závislostí
            userManager,
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object,
            new Mock<IUserConfirmation<ApplicationUser>>().Object
        );

        // Nastavení chování metody PasswordSignInAsync na neúspěšné přihlášení
        signInManagerMock.Setup(x => x.PasswordSignInAsync("neexistujici", "spatneHeslo", false, false))
            .ReturnsAsync(SignInResult.Failed);

        var loginService = new LoginService(signInManagerMock.Object);

        // Act
        var result = await loginService.LoginUserAsync("neexistujici", "spatneHeslo");

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Invalid username or password", result.ErrorMessage);
    }
}