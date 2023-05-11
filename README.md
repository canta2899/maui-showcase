# .NET MAUI App Example

A demo app that showcases .NET MAUI development using a Model View View-Model pattern.

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

