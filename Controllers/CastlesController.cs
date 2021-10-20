using System.Collections.Generic;
using KnightsTale.Service;
using Microsoft.AspNetCore.Mvc;

namespace KnightsTale.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CastlesController : ControllerBase
  {
    private readonly CastlesService _castlesService;
    private readonly KnightsService _knightsService;
    public CastlesController(CastlesService castlesService, KnightsService knightsService)
    {
      _castlesService = castlesService;
      _knightsService = knightsService;
    }
    [HttpGet]
    public ActionResult<List<Castle>> GetCastles()
    {
      try
      {
        var castles = _castlesService.Get();
        return Ok(castles);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{castleId}")]
    public ActionResult<Castle> GetCastleById(int castleId)
    {
      try
      {
        var castle = _castlesService.Get(castleId);
        return Ok(castle);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Castle> CreateCastle([FromBody] Castle castleData)
    {
      try
      {
        var castle = _castlesService.CreateCastle(castleData);
        return Ok(castle);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{castleId}/knights")]
    public ActionResult<List<Castle>> GetCastleCastle(int castleId)
    {
      try
      {
        var knights = _knightsService.GetByCastleId(castleId);
        return Ok(knights);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost("{castleId}/knights")]
    public ActionResult<Castle> CreateCastleCastle(int castleId, [FromBody] Castle knightData)
    {
      try
      {
        // Matches route param to the actual data
        knightData.CastleId = castleId;
        var knight = _knightsService.Create(knightData);
        return Ok(knight);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{castleId}")]
    public ActionResult<Castle> EditCastle(int castleId, [FromBody] Castle castleData)
    {
      try
      {
        var castle = _castlesService.Edit(castleId, castleData);
        return Ok(castle);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{castleId}")]
    public ActionResult<Castle> DeleteCastle(int castleId)
    {
      try
      {
        var castle = _castlesService.Delete(castleId);
        return Ok(castle);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}