using System.ClientModel;
using System.Net;

using OpenAI;
using OpenAI.Chat;

var apiKey = "";
//Environment.SetEnvironmentVariable("apikey", apiKey);
var baseUrl = "https://open.cherryin.cc/v1";
//var mode = "Qwen/Qwen3-8B";
//var mode = "tencent/Hunyuan-MT-7B";
var mode = "qwen/qwen3-8b(free)";
//var mode = "Qwen/Qwen2.5-7B-Instruct";

OpenAIClient client =new OpenAIClient(new ApiKeyCredential(apiKey),new OpenAIClientOptions(){ Endpoint = new Uri(baseUrl)});

ChatClient chatClient = client.GetChatClient(mode);

var sys = new SystemChatMessage("中英互译，用户如果输入内容为中文，则翻译为英文，如果输入内容为英文，则翻译为中文");
while (true) {
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("==============================\r\n");
    Console.WriteLine("请输入内容：\r\n");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
        break;
    var user = new UserChatMessage($"""{input}""");
    Console.WriteLine("正在翻译，请稍等...\r\n");
    var chat = chatClient.CompleteChat([sys, user]);
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    foreach(var item in chat.Value.Content)
    {
        Console.WriteLine(item.Text);
        System.Diagnostics.Debug.WriteLine(item.Text);
    }
}
Console.WriteLine("全部结束");
Console.ReadLine();
