using System.Collections.Generic;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Seeds
{
    public class SeedScale
    {
        public static List<Scale> ScaleSeed()
        {
            return new List<Scale>()
            {
                new Scale(){Id = 1, Name = "small"},
                new Scale(){Id = 2, Name = "medium"},
                new Scale(){Id = 3, Name = "large"},
            };
        }
    }
}