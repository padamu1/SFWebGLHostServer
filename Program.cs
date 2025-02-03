using SFHttpServer;
using SFHttpServer.Data;

public class Program
{
    class ProgramClass
    {
        private HttpApplication application;
        private string rootPath;

        public ProgramClass()
        {
            string currentDirectory = Environment.CurrentDirectory;
            rootPath = Path.Combine(currentDirectory, "src");

            application = new HttpApplication(new SFCSharpServerLib.Common.Data.SFServerInfo()
            {
                Url = "*",
                Port = 8000,
            });

            Console.WriteLine($"root path : {rootPath}");
            CheckDirectory(rootPath);

            application.RunAsync();
        }

        private async Task<SFHttpResponse> GetGameResource(SFHttpRequest request)
        {
            try
            {
                SFHttpResponse sFHttpResponse = new SFHttpResponse();
                sFHttpResponse.SetContentType(GetMimeType(request.Path));
                sFHttpResponse.SetStatus(200);

                byte[] fileData = File.ReadAllBytes(rootPath + "/" + request.Path);
                sFHttpResponse.SetBytes(fileData);
                return sFHttpResponse;
            }
            catch (Exception e)
            {
                SFHttpResponse sFHttpResponse = new SFHttpResponse();
                sFHttpResponse.SetContentType("text/plain");
                sFHttpResponse.SetStatus(500);
                return sFHttpResponse;
            }
        }

        private static string GetMimeType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLower();
            return ext switch
            {
                ".html" => "text/html",
                ".js" => "application/javascript",
                ".wasm" => "application/wasm",
                ".data" => "application/octet-stream",
                ".unityweb" => "application/octet-stream",
                ".css" => "text/css",
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
        }

        public void CheckDirectory(string dir)
        {
            var directories = Directory.GetDirectories(dir);

            foreach (var d in directories)
            {
                CheckDirectory(d);
            }

            var files = Directory.GetFiles(dir);
            foreach (var f in files)
            {
                CheckFile(f);
            }
        }

        private void CheckFile(string dir)
        {
            dir = dir.Replace(rootPath + "/", "");

            Console.WriteLine($"Get Method 등록 : {dir}");

            application.AddMethod(SFHttpServer.Data.HTTP_METHOD.GET, dir, GetGameResource);
        }
    }

    public static async Task Main(string[] args)
    {
        new ProgramClass();

        while (true)
        {
            await Task.Delay(1000);
        }
    }
}