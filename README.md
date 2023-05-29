# .NET MAUI App Example

A demo app that showcases .NET MAUI development using a Model View View-Model pattern. The app allows to visualize and post data which is stored on a [strapi](https://strapi.io/) CMS using JWT authentication. A sample test project is provided in order to illustrate how the business logic layer can be unit tested independently thanks to the **loose coupling** provided by the MVVM separation of concerns.

In order to run one should first setup the **strapi** project by running the following commands inside the `strapi` directory

```bash
yarn install
yarn build
yarn start
```

Then the MauiApp can be compiled from visual studio and deployed to your device or simulator. Make sure that `MauiAppExample\Shared.cs` contains the correct API base address since it is the one that will be used while the application is running.

## SecureStorage

The SecureStorage compatibility has been ensured only for iOS/MacCatalyst platforms, but it can be added for Windows or Android by following the steps reported on the [official docs](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/secure-storage?tabs=android).

### Using SecureStorage API on iOS and MacCatalyst

Here are the steps I had to accomplish in order to correctly use the SecureStorage API on both physical devices and the iOS simulator. 

#### Create a signing identity on XCode

By following [these](https://learn.microsoft.com/en-us/xamarin/ios/get-started/installation/device-provisioning/free-provisioning?tabs=macos#use-xcode-to-create-a-signing-identity-and-provisioning-profile) steps I had to create a blank XCode project and deploy it to my iOS device (iPhone 11) in order to generate a provisioning file. The **bundle identifier** of the iOS app had to be the same of the MAUI app (`com.companyname.mauiappexample` in this case).

#### Configuring Entitlements

I had to create the file `Platforms/iOS/Entitlements.plist` in which I had to configure the keychain access group for the current bundle identifier. This can be done through the Visual Studio editor, otherwise the file can be edited manually pasting the following code (be sure to change the bundle identifier if it differs).

```
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
	<key>keychain-access-groups</key>
	<array>
		<string>$(AppIdentifierPrefix)com.companyname.mauiappexample</string>
	</array>
</dict>
</plist>
```

Here's an explanation from the [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/secure-storage?tabs=android).

#### Deploying on MAUI

I had to source the custom `Entitlements.plist` file in `Platforms/iOS` (**source it again if it was already sourced**) and set the newly created provisioning profile and signing identity in the iOS bundle signing options in the project options menu. If possible, delete `bin` and `obj` folders and recompile the solution.

