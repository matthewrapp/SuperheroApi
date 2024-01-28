using Microsoft.AspNetCore.Mvc;
using SuperheroApi.Models;

using Microsoft.Extensions.Caching.Memory;

namespace SuperheroApi.Controllers;

[ApiController]
[Route("api/Superhero")]
public class SuperHeroController : ControllerBase
{

   private readonly SuperHeroContext _DBContext;
   // add a simple catch the this controller
   private readonly IMemoryCache _CACHE;

   public SuperHeroController(SuperHeroContext dbContext, IMemoryCache memoryCache)
   {
      _DBContext = dbContext;
      _CACHE = memoryCache;
   }

   [HttpGet]
   public IActionResult Get()
   {
      var superheros = _CACHE.GetOrCreate("allSuperHeroes", entry =>
      {
         // cache results for 30 seconds
         entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
         return _DBContext.SuperHeroes.ToList();
      });

      return Ok(superheros);
   }


   [HttpGet("{id}")]
   public async Task<IActionResult> GetById(string id)
   {
      var superhero = await _DBContext.SuperHeroes.FindAsync(id);
      // var superhero = await _CACHE.GetOrCreateAsync("superHeroById", async entry =>
      // {
      //    // cache result for 30 seconds
      //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
      //    return await _DBContext.SuperHeroes.FindAsync(id);
      // });
      return Ok(superhero);
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteById(string id)
   {
      var foundSuperhero = await _DBContext.SuperHeroes.FindAsync(id);
      if (foundSuperhero != null)
      {
         _DBContext.SuperHeroes.Remove(foundSuperhero);
         await _DBContext.SaveChangesAsync();
         return Ok(true);
      }
      return Ok(false);
   }

   [HttpPost()]
   public async Task<IActionResult> Create(SuperHero superHeroData)
   {
      _DBContext.SuperHeroes.Add(superHeroData);
      await _DBContext.SaveChangesAsync();
      return Ok(true);
   }

   [HttpPut("{id}")]
   public async Task<IActionResult> UpdateById(string id, SuperHero superHeroData)
   {
      var foundSuperhero = await _DBContext.SuperHeroes.FindAsync(id);
      if (foundSuperhero != null)
      {
         foundSuperhero.Name = superHeroData.Name;
         foundSuperhero.Superpowers = superHeroData.Superpowers;
         await _DBContext.SaveChangesAsync();
         return Ok(true);
      }
      return Ok(false);
   }
}
// using Microsoft.AspNetCore.Mvc;
// using SuperheroApi.Models;

// using Microsoft.Extensions.Caching.Memory;

// namespace SuperheroApi.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class SuperHeroController : ControllerBase
// {

//    private readonly SuperHeroContext _DBContext;
//    private readonly IMemoryCache _CACHE;

//    public SuperHeroController(SuperHeroContext dbContext, IMemoryCache memoryCache)
//    {
//       _DBContext = dbContext;
//       _CACHE = memoryCache;
//    }

//    [HttpGet]
//    public IActionResult Get()
//    {
//       var superheros = _DBContext.SuperHeroes.ToList();
//       return Ok(superheros);
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById(string id)
//    {
//       var superhero = await _DBContext.SuperHeroes.FindAsync(id);
//       return Ok(superhero);
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteById(string id)
//    {
//       var foundSuperhero = await _DBContext.SuperHeroes.FindAsync(id);
//       if (foundSuperhero != null)
//       {
//          _DBContext.SuperHeroes.Remove(foundSuperhero);
//          await _DBContext.SaveChangesAsync();
//          return Ok(true);
//       }
//       return Ok(false);
//    }

//    [HttpPost()]
//    public async Task<IActionResult> Create(SuperHero superHeroData)
//    {
//       _DBContext.SuperHeroes.Add(superHeroData);
//       await _DBContext.SaveChangesAsync();
//       return Ok(true);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> UpdateById(string id, SuperHero superHeroData)
//    {
//       var foundSuperhero = await _DBContext.SuperHeroes.FindAsync(id);
//       if (foundSuperhero != null)
//       {
//          foundSuperhero.Name = superHeroData.Name;
//          foundSuperhero.Superpowers = superHeroData.Superpowers;
//          await _DBContext.SaveChangesAsync();
//          return Ok(true);
//       }
//       return Ok(false);
//    }
// }
