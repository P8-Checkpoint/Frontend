using Moq;
using Services;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Helpers;
using Viewmodels;
using Wrappers;

namespace Tests.Viewmodels;

public class LandingPageViewModelTest
{
    private readonly LandingPageViewModel _sut;
    private readonly Mock<INavigationWrapper> _navigatorMock;
    private readonly Mock<IDataService> _dataServiceMock;
    private readonly Mock<IConnectionService> _connectionServiceMock;

    public LandingPageViewModelTest()
    {
        _navigatorMock = new Mock<INavigationWrapper>();
        _dataServiceMock = new Mock<IDataService>();
        _connectionServiceMock = new Mock<IConnectionService>();

        _sut = new LandingPageViewModel(_navigatorMock.Object, _dataServiceMock.Object, _connectionServiceMock.Object);
    }

    [Fact]
    public async Task Login_ClearsDataFirst_ExpectClearDataCalledAsync()
    {
        await _sut.Login("Username", "Password");

        _dataServiceMock.Verify(mock => mock.ClearDataAndLogout(), Times.Once);
    }

    [Fact]
    public async Task Login_LogsIn_ExpectLoginCalldWithUsernameAndPassword()
    {
        await _sut.Login("Username", "Password");

        _connectionServiceMock.Verify(mock => mock.LoginAsync("Username", "Password"), Times.Once);
    }

    [Fact]
    public async Task Login_GetsTokenFromStorage_ExpectSecureStorageGetTokenCalled()
    {
        await _sut.Login("Username", "Password");

        _dataServiceMock.Verify(mock => mock.SecureStorageGetAsync(StorageKeys.AuthTokenKey), Times.Once);
    }

    [Fact]
    public async Task Login_GetsCurrentUser_ExpectGetUserCalled()
    {
        await _sut.Login("Username", "Password");

        _dataServiceMock.Verify(mock => mock.GetCurrentUserAsync(), Times.Once);
    }

}
