# FastDeleteApp

FastDeleteApp is a lightweight, high-speed **depth-first folder deletion** utility written in C#.  
It’s designed to instantly remove large and stubborn folders like `node_modules` — even those with:
- Long file paths (> 260 characters)
- Locked read-only/system attributes
- Deeply nested directory structures

---

## Features
- **Depth-first deletion**
  Ensures children are deleted before their parent directories, avoiding "folder not empty" errors.
- **Long path support** (`\\?\` prefix)  
  Handles Windows paths beyond the normal 260-character limit.
- **Blazing fast**  
  Uses pure .NET I/O operations instead of slower shell commands.

---

## USAGE:
```bash
fda "c:\path\to\node_modules"
```
## **⚠️ Always double check before you enter the path.**

---

## How to Build

### 1. Install .NET SDK
Download and install the [.NET SDK](https://dotnet.microsoft.com/en-us/download).

### 2. Compile
```bash
dotnet build -c Release
```
