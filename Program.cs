using System.ClientModel;
using System.Net;

using OpenAI;
using OpenAI.Chat;

var apiKey = "sk-jooybxxxxxxxllmgpi";
//Environment.SetEnvironmentVariable("apikey", apiKey);
var baseUrl = "https://api.siliconflow.cn";
//var mode = "Qwen/Qwen3-8B";
//var mode = "tencent/Hunyuan-MT-7B";
var mode = "deepseek-ai/DeepSeek-V3.2";
//var mode = "Qwen/Qwen2.5-7B-Instruct";

OpenAIClient client =new OpenAIClient(new ApiKeyCredential(apiKey),new OpenAIClientOptions(){ Endpoint = new Uri(baseUrl)});

ChatClient chatClient = client.GetChatClient(mode);

var sys = new SystemChatMessage("你是一个翻译软件,将中文翻译为乌兹别克语（拉丁字母O'zbek tili）。翻译的内容用于工业设备触屏，与汽车线塑、加热板、非标自动化机器相关。翻译出的内容分别以三种模式的展示出，有1.正常翻译、2.简单翻译、3.超级缩写。输出示例：\r\n用户输入：出厂设置\r\n1.正常翻译:Zavod konfiguratsiyasi\r\n 2.简单翻译：Zavod konfiguratsiya\r\n3.超级缩写：Zavod konfig");
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
