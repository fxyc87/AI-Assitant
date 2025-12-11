C#调用 OPENAI库，调用国内AI库演示例子：

OpenAIClient client =new OpenAIClient(new ApiKeyCredential(apiKey),new OpenAIClientOptions(){ Endpoint = new Uri(baseUrl)});
ChatClient chatClient = client.GetChatClient(mode);
var sys = new SystemChatMessage("你是一个翻译软件");
while (true) {
    Console.WriteLine("==============================\r\n");
    Console.WriteLine("请输入内容：\r\n");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
        break;
    var user = new UserChatMessage($"""{input}""");
    Console.WriteLine("正在翻译，请稍等...\r\n");
    var chat = chatClient.CompleteChat([sys, user]);
    foreach(var item in chat.Value.Content)
    {
        Console.WriteLine(item.Text);
        System.Diagnostics.Debug.WriteLine(item.Text);
    }
}
Console.WriteLine("全部结束");
Console.ReadLine();
