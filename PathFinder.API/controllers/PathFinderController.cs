using Microsoft.AspNetCore.Mvc;
using PathFinder.API.utils;

namespace PathFinder.API.controllers;

public class PathFinderController : Controller
{
    // check health of the API
    [HttpGet("status")]
    public IActionResult GetStatus()
    {
        String message = "The API is healthy";
        return Ok(new { message });
    }

    [HttpPost("pathFinder")]
    public IActionResult GetShortestPath([FromBody] PathRequest request)
    {
        utils.PathFinder pathFinder = new utils.PathFinder(request.Grid,request.Start,request.End);
        List<Point> path = pathFinder.findShortestPath();
        return Ok(new { result = path });
    }
}