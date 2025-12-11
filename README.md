**C#调用 OPENAI库，调用国内AI库演示例子：**



OpenAIClient client =new OpenAIClient(new ApiKeyCredential(apiKey),new OpenAIClientOptions(){ Endpoint = new Uri(baseUrl)});

ChatClient chatClient = client.GetChatClient(mode);

var sys = new SystemChatMessage("你是一个翻译软件");

while (true) {

&nbsp;   Console.WriteLine("==============================\\r\\n");

&nbsp;   Console.WriteLine("请输入内容：\\r\\n");

&nbsp;   var input = Console.ReadLine();

&nbsp;   if (string.IsNullOrEmpty(input))

&nbsp;       break;

&nbsp;   var user = new UserChatMessage($"""{input}""");

&nbsp;   Console.WriteLine("正在翻译，请稍等...\\r\\n");

&nbsp;   var chat = chatClient.CompleteChat(\[sys, user]);

&nbsp;   foreach(var item in chat.Value.Content)

&nbsp;   {

&nbsp;       Console.WriteLine(item.Text);

&nbsp;       System.Diagnostics.Debug.WriteLine(item.Text);

&nbsp;   }

}

Console.WriteLine("全部结束");

Console.ReadLine();



