using API.API.Responses.Dto;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.API.Controllers;

using UserProfileDto = PlayerProfileDto;

[ApiController]
[Route("api/player")]
public class PlayerController
{
    /// <summary>
    /// Return user profile data
    /// </summary>
    /// <remarks>
    /// Find user in database by id
    /// Find his referrer if he exist
    /// Build response object
    /// </remarks>
    /// <param name="userTgId"></param>
    /// <returns>User profile data</returns>
    /// <response code="200">User found. Returns profile</response>
    /// <response code="404">User not found</response>
    [ProducesResponseType(typeof(UserProfileDto), 200)]
    [ProducesResponseType(404)]
    [HttpGet("get/{userTgId:long}")]
    public async Task<IResult> GetById(long userTgId)
    {
        var player = new UserProfileDto(new Player());

        return player is null ? Results.NotFound(userTgId) : Results.Ok(player);
    }
}