# Introduction

**Smart Store** is a modern online shop for computer equipment and various electronics, built with **.NET 8 Core** and **Razor Pages**.
It provides functionality for both **administrators** and **customers**, offering a complete e-commerce experience.

## Technologies Used
- **.NET 8 Core**
- **Razor Pages**
- **Entity Framework Core**
- **SQL Server**
- **Bootstrap**
- **MailJet API** (for email notifications)
- **Braintree** (for payments)
- **Facebook Authentication**

## Administrator Features

The **Admin Panel** allows managing the entire store ecosystem:

- Add a new administrator  
- Add, edit, and delete **categories**  
- Add, edit, and delete **products**  
- View and manage **order requests**  
- Change **order status**  
- Update customer data for a specific order (address, contact info, etc.)  
- Confirm or cancel orders  
- Handle **returns** and **exchanges** while preserving order value

## Customer Features

The **Customer Portal** provides an intuitive shopping experience:

- Register a new account
- Browse and filter products by **category** or **search by name**
- Add items to the **cart**
- Place orders

## Screenshots

| | | |
|:--:|:--:|:--:|
| ![Screenshot 2](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_2.png) | ![Screenshot 4](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_4.png) | ![Screenshot 3](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_3.png) | 
![Screenshot 1](https://github.com/Kravtseniuk/Smart-Store/raw/main/SmartStore/wwwroot/images/screenshots/screenshot_1.png)

## Installation

1. **Clone the repository**.
2. **Install and configure Microsoft SQL Server**.
3. Ensure that the **.NET 8 SDK** is installed on your system.

## Configuration

#### 1️⃣ Database Connection
1. In **appsettings.json**, set your database name:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=YourDatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```

#### 2️⃣ Facebook Authentication
1. Go to Facebook Developers and log in.
2. Create a new app and copy your App ID and App Secret.
3. In your **Program.cs**, add:
    ```csharp
    builder.Services.AddAuthentication()
    .AddFacebook(options =>
        {
            options.AppId = "facebook_app_id";
            options.AppSecret = "facebook_app_secret";
        });
    ```

#### 3️⃣ MailJet Configuration (Email Notifications)
1. Create or log in to your MailJet account.
2. Create a new app and obtain your **API Key and Secret Key**.
3. Add them to **appsettings.json**:
    ```json
    "MailJet": {
      "ApiKey": "your_api_key",
      "SecretKey": "your_secret_key"
    }
    ```

#### 4️⃣ Braintree Configuration (Payment Integration)
1. Log in or register at Braintree
2. Create a Merchant Account and copy your:
    - Merchant ID
    - Public Key
    - Private Key
3. Add them to **appsettings.json**:
    ```json
    "BrainTree": {
      "Environment": "sandbox",
      "MerchantId": "your_merchant_id",
      "PublicKey": "your_public_key",
      "PrivateKey": "your_private_key"
    }
    ```

## Run the Application
1. Apply database migrations:
    ```bash
    dotnet ef database update
    ```
2. Build and run the project:
    ```bash
    dotnet run
    ```
3. Open your browser at:
   http://localhost:5000