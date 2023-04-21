using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Wrappers;

public interface INavigationWrapper
{
    /// <summary>
    /// Routes to a named route and clears the history such that the user cannot navigate back
    /// </summary>
    /// <param name="route">The named route. <see cref="NavigationKeys"/></param>
    /// <param name="isAnimated">Is navigation animated/></param>
    /// <returns></returns>
    Task RouteAndReplaceStackAsync(string route, bool isAnimated = true);

    /// <summary>
    /// Overload of <see cref="RouteAndReplaceStackAsync(string)"/> which also passes a query dict/>
    /// </summary>
    /// <param name="route">The named route. <see cref="NavigationKeys"/></param>
    /// <param name="queryDict">A query dict object that will be passed to the page/></param>
    /// <param name="isAnimated">Is navigation animated/></param>
    /// <returns></returns>
    Task RouteAndReplaceStackAsync(string route, Dictionary<string, object> queryDict, bool isAnimated = true);

    /// <summary>
    /// Routes to a named route
    /// </summary>
    /// <param name="route">The named route. <see cref="NavigationKeys"/></param>
    /// <param name="isAnimated">Is navigation animated/></param>
    /// <returns></returns>
    Task RouteAsync(string route, bool isAnimated = true);

    /// <summary>
    /// Overload of <see cref="RouteAsync(string)"/> which also passes a query dict
    /// </summary>
    /// <param name="route">The named route. <see cref="NavigationKeys"/></param>
    /// <param name="queryDict">A query dict object that will be passed to the page/></param>
    /// <param name="isAnimated">Is navigation animated/></param>
    /// <returns></returns>
    Task RouteAsync(string route, Dictionary<string, object> queryDict, bool isAnimated = true);

    /// <summary>
    /// Returns the root level page in the downstream path from the current location
    /// For example //monkeys/detail will return monkeys.
    /// </summary>
    /// <returns>A <see cref="NavigationKeys"/> for the root level page</returns>
    string GetRootLevelPage();

    /// <summary>
    /// Navigates one step back in the navigation stack
    /// </summary>
    /// <param name="isAnimated">Boolean indicating whether transition should be animated</param>
    /// <returns></returns>
    Task NavigateBackAsync(bool isAnimated);

    /// <summary>
    /// Overload of <see cref="NavigateBackAsync(bool)"/> which also passes a query dict
    /// </summary>
    /// <param name="isAnimated">Boolean indicating whether transition should be animated</param>
    /// <param name="queryDict">A query dict object that will be passed to the page</param>
    /// <returns></returns>
    Task NavigateBackAsync(bool isAnimated, Dictionary<string, object> queryDict);

    /// <summary>
    /// Returns the current route
    /// </summary>
    /// <returns></returns>
    string GetCurrent();
}
