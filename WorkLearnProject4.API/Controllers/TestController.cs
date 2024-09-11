// using Microsoft.AspNetCore.Mvc;
// using WorkLearnProject4.Data;
//
// namespace WorkLearnProject4.API.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class TestController : Controller
// {
//     private readonly TestRepo _testRepo;
//
//     public TestController(TestRepo repo)
//     {
//         _testRepo = repo;
//     }
//     [HttpGet]
//     public string Get()
//     {
//         return _testRepo.Get();
//     }
// }