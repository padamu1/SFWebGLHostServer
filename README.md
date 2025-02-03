## 🌐 Unity WebGL Hosting Server

This project is designed to **easily host Unity WebGL projects**.

---

## 📌 How to Use

### 1⃣ Set WebGL Build Path  
Locate the following code in the `Program` class:

```csharp
string currentDirectory = Environment.CurrentDirectory;
rootPath = Path.Combine(currentDirectory, "src");
```

Replace `"src"` with **the folder name containing your WebGL build**.  
For example, if your `Build` folder contains `index.html` and the `build` directory:

```csharp
rootPath = Path.Combine(currentDirectory, "Build");
```

---

### 2⃣ Configure Port  
Find the following code in the `Program` class:

```csharp
application = new HttpApplication(new SFCSharpServerLib.Common.Data.SFServerInfo()
{
    Url = "*",
    Port = 8000,
});
```

Modify the `Port` value to the port you wish to serve on.  
For example, to **run on port 8080**, update it as follows:

```csharp
Port = 8080;
```

---

## 🖥️ Supported Operating Systems  

✅ **Windows**  
✅ **Linux (arm64)**  

The default configuration is set for **Linux-arm64**.

### 🚀 How to Switch Execution Environment  
1. Navigate to the `Library/Dll/` directory of the project.  
2. Locate the **zip file corresponding to your target OS**.  
3. Extract the zip file and place its contents **under the `Library/` directory**.  

---

## 🎯 Additional Notes  
- Simply place the Unity WebGL build in the specified folder for instant hosting.  
- Lightweight HTTP server for fast and easy deployment.  

---

## 🐟 License  
This project is licensed under the [MIT License](LICENSE). Feel free to use and modify! 😊  

