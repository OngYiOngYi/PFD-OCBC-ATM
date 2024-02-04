namespace WebApplication1.Models
{
    public class OpenAIRequest
    {
        public string Model { get; set; } = "text-davinci-003"; // Use the latest or appropriate model
        public string Prompt { get; set; }
        public int MaxTokens { get; set; } = 150;
    }

    public class OpenAIResponse
    {
        public List<ResponseChoice> Choices { get; set; } = new List<ResponseChoice>();
    }

    public class ResponseChoice
    {
        public string Text { get; set; }
    }
}