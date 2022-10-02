using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    public class ErrorController: ApiController{
        [Route("/error")]
        public IActionResult Error(){
            return Problem(); 
        }
        
    }
}