using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viewmodels.Tabs;
using Wrappers;
using Tests.Helpers;

namespace Tests.Viewmodels.Tabs;

public class JobListPageViewModelTest
{
    private readonly JobListPageViewModel _sut;
    private readonly Mock<INavigationWrapper> _navigatorMock;
    private readonly Mock<IDataService> _dataServiceMock;

    public JobListPageViewModelTest()
    {
        _navigatorMock = new Mock<INavigationWrapper>();
        _dataServiceMock = new Mock<IDataService>();

        _sut = new JobListPageViewModel(_navigatorMock.Object, _dataServiceMock.Object);
    }

    [Fact]
    public void JobClicked_CheckCommandExistence_NotNull()
    {
        Assert.NotNull(_sut.JobClickedCommand);
    }

    [Fact]
    public async Task InitializeAsync_SetsCurrentUser_ExpectCurrentUserSetAsync()
    {
        var expected = DataHelper.GetUser(1).UserName;
        _sut.CurrentUser = null;

        _dataServiceMock.Setup(mock => mock.GetCurrentUserAsync()).ReturnsAsync(DataHelper.GetUser(1));

        await _sut.InitializeAsync();

        var actual = _sut.CurrentUser?.UserName;

        Assert.Equal(expected, actual);
    }
}
