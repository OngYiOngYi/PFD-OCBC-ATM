using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class Voice : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            string OutputResult = "";
            var Openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var completions = Openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Result.Completions) 
            {
                OutputResult += completion.Text;
            }

            return Ok(OutputResult);
        }
    }
}
