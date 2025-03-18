
# Problem 

This bug occurs when a BindableLayout (e.g. with a VerticalStackLayout) is nested inside a ScrollView. The issue isn't readily apparent, because most of the time there's no problem. 

Ordinarily, the ScrollView correctly resizes itself when the BindableLayout.ItemsSource is changed; however, this doesn't appear to happen if the container of the ScrollView (and by extension the nested BindableLayout) is hidden (i.e. IsVisible="False") when the change to BindableLayout.ItemsSource occurs.

It's important to note that the issue doesn't occur if the ScrollView itself is hidden (i.e. IsVisible="False") when the change to BindableLayout.ItemsSource occurs; the issue seems specifically related to whether the ScrollView's *container* is visible.

The issue doesn't appear to affect Android.

This may be related to [another issue](https://github.com/dotnet/maui/issues/12727) that was closed a while ago (that issue didn't take the container's visibility into account though).

# Expected Behaviour

The ScrollView should be resized correctly when the ItemsSource of the nested BindableLayout is changed, regardless of whether its container is visible.

# Environment

## Platform

### iOS

- iOS 18.3.1 (.NET 9) (physical device using Hot Reload)

## Maui Version
Output of 'dotnet workload list' command:

**Installed Workload Id**: maui-windows

**Manifest Version**: dotnet workload list

**Installation Source**: SDK 9.0.200, VS 17.14.35821.62.3

# How To Replicate

You'll notice two pages. Stay on the first page to begin with. You should see a list of numbers, which can be scrolled vertically.

1. Click the 'Letters' button at the top of the page. You should now see a list of letters (this is the BindableLayout.ItemsSource changing). The ScrollView should have resized properly.
2. Click the 'Numbers' button at the top of the page. You should once again see a list of numbers. Again, the ScrollView should have resized properly.
3. Click the 'Toggle IsVisible' button in the top right. The list of numbers should disappear.
4. Click the 'Letters' button at the top of the page.
5. Click the 'Toggle IsVisible' button in the top right. The list of letters should appear; however, you should notice that the ScrollView didn't resize properly and has retained the height of the longer numbers list.
6. Click the 'Toggle IsVisible' button again. The letters should disappear.
7. Click the 'Numbers' button.
8. Click the 'Toggle IsVisible' button. The list of numbers should appear; however, you should notice that the ScrollView didn't resize properly and instead is sized for the smaller list of letters, causing the subsequent numbers to be 'bunched up' at the bottom.
9. Click the 'Letters' button. The letters should appear and the ScrollView should be properly sized.
10. Click the 'Numbers' button. The numbers should appear and the ScrollView should be properly sized. Steps 9 and 10 show that the issue is specifically related to the value of the container's IsVisible property at the time the BindableLayout.ItemsSource is changed.
11. Click the button in the bottom right (i.e. the 'Works' tab with the tick icon). You should be taken to a similar page (it looks exactly the same except the colour scheme is different). The XAML of this page is almost identical, with the only difference being that the ScrollView's IsVisible property is changed, not the IsVisible property of its container.
12. Repeat steps 1 to 8 on this page. You shouldn't notice any ScrollView sizing issues on this page.