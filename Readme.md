# JWT Decoder

A secure, client-side JWT (JSON Web Token) decoder built with Blazor WebAssembly and .NET 9. This application allows you to safely decode and inspect JWT tokens without sending any data to external servers.

## 🚀 Features

- **Client-Side Processing**: All JWT decoding happens in your browser - no data is sent to any server
- **Real-Time Decoding**: Instantly decode JWT tokens as you paste them
- **Three-Section Display**: Clear separation of Header, Payload, and Signature components
- **Copy to Clipboard**: Easy copying of decoded sections with one-click buttons
- **Responsive Design**: Works seamlessly on desktop and mobile devices
- **Error Handling**: Comprehensive validation and error messages for invalid tokens
- **Modern UI**: Clean, intuitive interface built with Blazor WebAssembly

## 🖥️ Interface

The application features a two-column layout:
- **Left Panel**: JWT token input textarea
- **Right Panel**: Decoded sections (Header, Payload, Signature)

## 🛠️ Technology Stack

- **Framework**: .NET 9
- **UI Framework**: Blazor WebAssembly
- **Language**: C# 13.0
- **Styling**: CSS3 with Flexbox
- **Package Manager**: NuGet

## 📦 Dependencies

```xml
<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly" Version="9.0.9" />
<PackageReference Include="Microsoft.AspNetCore.Components.WebAssembly.DevServer" Version="9.0.9" PrivateAssets="all" />
```

## 🚦 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A modern web browser

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Netonia/JWTDecoder.git
   cd JWTDecoder
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to the displayed URL (typically `https://localhost:5001`)

### Building for Production

```bash
dotnet publish -c Release
```

## 📁 Project Structure

```
JWTDecoder/
├── Pages/
│   ├── Home.razor              # Main JWT decoder page
│   └── Home.razor.css          # Page-specific styles
├── Layout/
│   ├── MainLayout.razor        # Application layout
│   └── MainLayout.razor.css    # Layout styles
├── Services/
│   └── JwtDecoderService.cs    # JWT decoding logic
├── Program.cs                  # Application entry point
├── App.razor                   # Root component
├── _Imports.razor              # Global using statements
└── JWTDecoder.csproj          # Project file
```

## 🔧 How It Works

### JWT Decoding Process

1. **Input Validation**: Checks if the JWT has the correct format (3 parts separated by dots)
2. **Base64URL Decoding**: Converts the Base64URL encoded header and payload to JSON
3. **JSON Formatting**: Pretty-prints the decoded JSON for better readability
4. **Error Handling**: Provides detailed error messages for invalid tokens

### Key Components

- **JwtDecoderService**: Core service that handles JWT decoding logic
- **JwtDecodedResult**: Data model for decoded JWT results
- **Home.razor**: Main UI component with two-panel layout
- **MainLayout.razor**: Simplified layout without navigation menu

## 🎯 Usage

1. **Paste JWT Token**: Copy your JWT token and paste it into the left textarea
2. **Decode**: Click the "Decode JWT" button or let it auto-decode
3. **Inspect**: View the decoded Header, Payload, and Signature in the right panel
4. **Copy**: Use the copy buttons to copy individual sections to your clipboard

### Example JWT Structure

A typical JWT consists of three parts:

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

Which decodes to:
- **Header**: `{"alg":"HS256","typ":"JWT"}`
- **Payload**: `{"sub":"1234567890","name":"John Doe","iat":1516239022}`
- **Signature**: `SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c`

## 🔒 Security & Privacy

- **No Server Communication**: All processing happens in your browser
- **No Data Storage**: Tokens are not stored anywhere
- **Client-Side Only**: No backend server required
- **Open Source**: Full transparency of the decoding process