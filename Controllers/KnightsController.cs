using System.Collections.Generic;
using KnightsTale.Models;
using KnightsTale.Service;
using Microsoft.AspNetCore.Mvc;

namespace KnightsTale.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KnightsController : ControllerBase
  {
    private readonly KnightsService _knightsService;
    private readonly CastlesService _castlesService;
    public KnightsController(KnightsService knightsService, CastlesService castlesService)
    {
      _knightsService = knightsService;
      _castlesService = castlesService;
    }
    [HttpGet]
    public ActionResult<List<Knight>> GetKnights()
    {
      try
      {
        var knights = _knightsService.Get();
        return Ok(knights);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{knightId}")]
    public ActionResult<Knight> GetKnightById(int knightId)
    {
      try
      {
        var knight = _knightsService.Get(knightId);
        return Ok(knight);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPost]
    public ActionResult<Knight> CreateKnight([FromBody] Knight knightData)
    {
      try
      {
        var knight = _knightsService.CreateKnight(knightData);
        return Ok(knight);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{knightId}/castles")]
    public ActionResult<List<Castle>> GetKnightCastle(int knightId)
    {
      try
      {
        var castles = _castlesService.GetByKnightId(knightId);
        return Ok(castles);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost("{knightId}/castles")]
    public ActionResult<Castle> CreateKnightCastle(int knightId, [FromBody] Castle castleData)
    {
      try
      {
        // Matches route param to the actual data
        castleData.KnightId = knightId;
        var castle = _castlesService.Create(castleData);
        return Ok(castle);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpPut("{knightId}")]
    public ActionResult<Knight> EditKnight(int knightId, [FromBody] Knight knightData)
    {
      try
      {
        var knight = _knightsService.Edit(knightId, knightData);
        return Ok(knight);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpDelete("{knightId}")]
    public ActionResult<Knight> DeleteKnight(int knightId)
    {
      try
      {
        var knight = _knightsService.Delete(knightId);
        return Ok(knight);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}