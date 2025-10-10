# Product Requirements Document (PRD)
## Project: JWT Decoder – Blazor WebAssembly One-Page App

### 1. Overview
A simple, client-side Blazor WebAssembly app to decode JSON Web Tokens (JWTs) without sending data to a server. The tool allows developers to paste a JWT and instantly view the header and payload in formatted JSON.

### 2. Goals
- Decode JWTs locally for security and privacy.
- Provide clear, formatted views of header and payload.
- Validate JWT structure and highlight errors.

### 3. Non-Goals
- No token signature verification.
- No authentication, networking, or API calls.
- No persistent data storage.

### 4. Target Users
- Developers working with authentication systems.
- QA engineers inspecting tokens.
- Students learning about JWTs.

### 5. Core Features
#### 5.1 Input
- TextArea for pasting JWT string.
- “Decode” button or automatic decoding on input.

#### 5.2 Output
- **Header** and **Payload** sections formatted as pretty-printed JSON.
- Visual feedback for invalid tokens.
- Copy-to-clipboard buttons for each decoded part.

#### 5.3 Validation
- Detect and display structural errors (missing parts, invalid Base64).
- Optional real-time validation as user types.

### 6. UI/UX
- Single-page layout using Blazor.
- Responsive design.
- Light and dark theme toggle (optional).
- Clear separation between input and output panels.

#### Layout
| Section | Description |
|----------|--------------|
| Header   | App title + optional theme toggle |
| Input    | TextArea for JWT + decode button |
| Output   | Two JSON viewers: Header, Payload |
| Footer   | Minimal credits/version info |

### 7. Technical Requirements
- **Framework:** .NET 8 Blazor WebAssembly (standalone).
- **Storage:** None (all in-memory).
- **Libraries:**
  - `System.Text.Json` for JSON parsing.
  - Optional: `ClipboardJS` interop for copy buttons.
- **Error Handling:** Graceful fallback for invalid JWTs.
- **Performance:** Instant decoding; no external calls.

### 8. Security
- All decoding happens client-side.
- No network requests or data collection.
- No token validation or key handling.

### 9. Future Enhancements (Out of Scope)
- JWT signature verification with public key input.
- JWT creation/generation tool.
- URL-safe token sharing.

### 10. Acceptance Criteria
- User pastes a valid JWT → header and payload decoded correctly.
- Invalid JWT → clear error message shown.
- Works offline.
- Loads and decodes within 1 second for typical tokens.
