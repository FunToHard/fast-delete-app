# FastDelete

FastDelete is a lightweight, high-speed **depth-first folder deletion** utility written in C#.  
It’s designed to instantly remove large and stubborn folders like `node_modules` — even those with:
- Long file paths (> 260 characters)
- Locked read-only/system attributes
- Deeply nested directory structures

---

## Features
- **Depth-first deletion** (post-order traversal)  
  Ensures children are deleted before their parent directories, avoiding "folder not empty" errors.
- **Long path support** (`\\?\` prefix)  
  Handles Windows paths beyond the normal 260-character limit.
- **Attribute reset**  
  Automatically removes read-only/system attributes before deletion.
- **Drag & Drop ready**  
  Simply drag a folder onto the executable to delete it.
- **Blazing fast**  
  Uses pure .NET I/O operations instead of slower shell commands.

---

## How to Build

### 1. Install .NET SDK
Download and install the [.NET SDK](https://dotnet.microsoft.com/en-us/download).

### 2. Compile
```bash
dotnet build -c Release
