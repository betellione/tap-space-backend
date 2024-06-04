using API.API.Responses.Dto;
using API.Data.Models;

namespace API.API.Services;

using API.Responses;

public class PlayerService
{
    public async Task<PlayerProfileDto> GetByTgId(long id)
    {
        var userProfile = new PlayerProfileDto(new Player());

        return userProfile;
    }
}