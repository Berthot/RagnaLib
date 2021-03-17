using System.Collections.Generic;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class ElementCsv
    {
        public string Name { get; set; }
        public short Tier { get; set; }
        public short Neutral { get; set; }
        public short Water { get; set; }
        public short Earth { get; set; }
        public short Fire { get; set; }
        public short Wind { get; set; }
        public short Poison { get; set; }
        public short Holy { get; set; }
        public short Dark { get; set; }
        public short Ghost { get; set; }
        public short Undead { get; set; }
        
        /*
        Neutral
        Water
        Earth
        Fire
        Wind
        Poison
        Holy
        Dark
        Ghost
        Undead
         */
    }
}