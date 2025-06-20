using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        private List<string> _availableClasses = new List<string>
        {
            "M101 - Mathematics 101",
            "CS102 - Computer Science 102",
            "M103 - Mathematics 103",
            "CS104 - Computer Science 104",
            "PHY105 - Physics 105",
        };

        public ClassController() { }

        [HttpGet("available-classes")]
        public IActionResult GetAvailableClasses()
        {
            return Ok(_availableClasses);
        }
    }


}
