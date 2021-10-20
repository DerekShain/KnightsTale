using System.Collections.Generic;
using KnightsTale.Models;
using KnightsTale.Repositories;

namespace KnightsTale.Service
{
  public class KnightsService
  {
    private readonly KnightsRepository _ks;
    public KnightsService(KnightsRepository ks)
    {
      _ks = ks;
    }
    public Knight CreateKnight(Knight knightData)
    {
      return _ks.Create(knightData);
    }
    public List<Knight> Get()
    {
      return _ks.Get();
    }
    public Knight Get(int knightId)
    {
      var knight = _ks.Get(knightId);
      if (knight == null)
      {
        throw new System.Exception("Invalid Knight Id");
      }
      return knight;
    }
    public Knight Edit(int knightId, Knight knightData)
    {
      var knight = Get(knightId);

      knight.Name = knightData.Name ?? knight.Name;
      knight.Sword = knightData.Sword ?? knight.Sword;
      knight.Skill = knightData.Skill;
      knight.Type = knightData.Type ?? knight.Type;
      _ks.Edit(knightId, knightData);
      return knight;
    }
    public Knight Delete(int knightId)
    {
      var knight = Get(knightId);
      _ks.Delete(knightId);
      return knight;
    }
  }
}
