using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace WebApplication1.Controllers
{
    //[Route("api/[controller]")]
  
    public class Voice : ControllerBase
    {
        [HttpGet]
        [Route("UseChatGPT")]
        public async Task<IActionResult>UseChatGPT(string query)
        {
            string OutputResult = "";
            var Openai = new OpenAIAPI("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");
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = query;
            completionRequest.Model = OpenAI_API.Models.Model.Davinci;

            var completions = Openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Result.Completions) 
            {
                OutputResult += completion.Text;
            }

            return Ok(OutputResult);
        }
    }
}
