# 📱 AppiumDemoTest Framework - Cross-Platform Mobile UI Testing (Android & iOS)

This framework is a cross-platform Appium-based test automation solution built with **.NET 7**, **NUnit**, and **Appium.WebDriver**. It supports:

* ✅ Android and iOS mobile app automation
* ✅ Cross-platform testing via **Appium**, **BrowserStack**, or local setup
* ✅ Environment and profile-based config (dev, sit, etc.)
* ✅ CLI support for `--platform`, `--environment`
* ✅ Page Object Model structure

---

## 🧱 Project Structure

```
C:.
│   .gitattributes
│   .gitignore
│   AppiumDemoTest.sln
│   global.json
│
└───AppiumDemoTest
    │   AppiumDemoTest.csproj
    │   AppiumDemoTest.csproj.user
    │   global.json
    │
    ├───Apk
 
    ├───Config
    │       AppConfig.cs
    │       appsettings.android.dev.json
    │       appsettings.android.sit.json
    │       appsettings.ios.dev.json
    │       appsettings.ios.sit.json
    │       appsettings.json
    │       ConfigReader.cs
    │
    ├───Drivers
    │       DriverFactory.cs
    │
    ├───Features
    │       AppumDemo.feature
    │       AppumDemo.feature.cs
    │
    ├───Hooks
    │       Hooks.cs
    │
    
    ├───Pages
    │       BasePage.cs
    │       LandingPage.cs
    │       LoginPage.cs
    │       ProductPage.cs
    │
    ├───StepDefinitions
    │       AppiumDemoSteps.cs
    │
    └───Util
            ActionsHelper.cs
```

---

## 🛠 Prerequisites

* .NET SDK 7 or 8
* Visual Studio or VS Code
* Android Studio (for local Android tests)
* BrowserStack for ios testing
* Appium Inspector for finding the elements/xpath
* Selenium support

---

## 📦 NuGet Packages

Install the required packages:

```bash
# Run inside the solution directory

# Appium
dotnet add package Appium.WebDriver

# NUnit
dotnet add package NUnit

# NUnit Test Adapter (for Visual Studio)
dotnet add package NUnit3TestAdapter

# Microsoft Configuration
dotnet add package Microsoft.Extensions.Configuration

dotnet add package Microsoft.Extensions.Configuration.Json
```
---

## ⚙️ Configuration Files

* `appsettings.json`: base settings
* `appsettings.{PLATFORM}.{ENV}.json`: platform-specific(android/ios), env-specific (e.g., QA, Prod)

Example:

```json
{
  "AppConfig": {
    "platformName": "Android",
    "deviceName": "emulator-5554",
    "platformVersion": "15",
    "appPackage": "org.simple.clinic",
    "appActivity": "org.simple.clinic.PolicyManagementActivity",
    "automationName": "UiAutomator2",
    "noReset": true,
    "app": "AppiumDemo4.apk",
    "username": "bob@example.com",
    "password": "10203040",
    "host": "http://127.0.0.1:4723"
  }
}
```

---

## 🚀 Run Tests

### ✅ Run with CLI arguments

```bash
# Run for Android
> dotnet test -- --platform android --environment dev

# Run for iOS on BrowserStack
> dotnet test -- --platform ios --environment dev
```

### ✅ Run in Parallel

```bash
# Run Android and iOS in parallel (terminal 1 & 2)
> dotnet test -- --platform android &
> dotnet test -- --platform ios
```

---

## ☁️ BrowserStack Integration

1. Upload your app:

```bash
curl -u "<username>:<access_key>" \
  -X POST "https://api-cloud.browserstack.com/app-automate/upload" \
  -F "file=@path/to/app.ipa"
```

2. Update `profiles/appsettings.browserstack-ios.json`:

```json
{
  "AppConfig": {
    "PlatformName": "iOS",
    "PlatformVersion": "16.0",
    "DeviceName": "iPhone 14",
    "AutomationName": "XCUITest",
    "App": "bs://<your-app-id>",
    "AppiumServerUrl": "http://<username>:<access_key>@hub-cloud.browserstack.com/wd/hub"
  }
}
```

---

## 📂 Environment Variables (optional)

You can override values using:

* CLI: `--platform ios --ENVIRONMENT dev  
* Env vars: `ENVIRONMENT`, `PLATFORM`

---

## 💡 Tips

* Always wait for elements with `WebDriverWait`
* Use platform-specific locators via `if (platform == "ios") ...`
* Set `ParallelScope.All` to run tests concurrently


---

## 🙋 Need Help?

Raise an issue or contact the maintainer via GitHub.

---
