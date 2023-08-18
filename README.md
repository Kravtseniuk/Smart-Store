**Smart Store** is an online shop specializing in selling computer equipment and various electronics. It operates based on **.NET 7 and Razor Pages** technologies.

It features both administrator and customer functionality.

Smart Store Admin allows you to:

- Add a new administrator.
- Add, edit, and delete categories.
- Add, edit, and delete products.
- View requests submitted for product orders and change their status.
- Manage orders.
- Update user information in an order: Ability to make changes to user data associated with a specific order, such as delivery address, contact details, etc.
- Confirm or cancel an order: Ability to confirm that an order is ready for processing and shipping, or to cancel it if necessary.
- Return or exchange an order: Ability to provide customers with the option to return or exchange items while preserving the value of the previously made order.

Smart Store Customer allows you to:

- Register your account.
- Browse the product catalog.
- Filter products by categories and find items by name.
- Add items to the cart.
- Place an order.

![Project Screenshot 1](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_1.png)

![Project Screenshot 2](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_2.png)

![Project Screenshot 3](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_3.png)

![Project Screenshot 4](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_4.png)


# Installation

#### Clone the repository: https://github.com/Kravtseniuk/Smart-Store.git
#### Install and configure the Microsoft SQL Server.

# Configuration

#### 1. Go to the `appsettings.json` file and name the database.
`"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DbNameGoesHere;Trusted_Connection=True;MultipleActiveResultSets=true"`

#### 2. The project has Facebook authorization by default, how to configure it:

- Go to [Facebook Developers](https://developers.facebook.com/) and log in to your account.

- Create a new application that will represent your project. Remember the App ID, as you will use it later.

- In the application settings, add the Web platform and specify the allowed domains to interact with your project.

- Open the `Program.cs` configuration file of your project where the configuration data is stored and add Facebook App ID and App Secret to your project settings:
`builder.Services.AddAuthentication().AddFacebook(Options =>
{
    Options.AppId = "facebook:app_id";
    Options.AppSecret = "facebook:app_secret"
});`

#### 3. The MailJet service is used to send a notification of a new order to the administrator, how to configure it:

- Create or log in to your MailJet account.

- Create a new application, in your MailJet account, go to the "My Apps" section and create a new App. Select the type of application.

- After creating the application, you will receive the API keys: API Key and API Secret Key. These keys are used to authenticate and interact with the MailJet API.

- Go to the `appsettings.json` file and set the `"MailJet" keys: {
  "ApiKey": "",
  "SecretKey": ""
}`

#### 4. The BrainTree service is used to pay for stamps with cards, how to configure it:

- Create or sign in to your Braintree account.

- In your Braintree account, create a new Merchant Account. Choose the type of account that suits your business (for example, Merchant or Nonprofit organization).

- After creating a merchant account, you will receive API keys: Public Key, Private Key, and Merchant ID. These keys are used to authenticate and interact with the Braintree API.

- Go to the `appsettings.json` file and set the keys `"BrainTree": {
  "Environment": "sandbox",
  "MerchantId": "",
  "PublicKey": "",
  "PrivateKey": ""
}`

# Run

- Compile final program from source files (you will need .NET 7 environment)