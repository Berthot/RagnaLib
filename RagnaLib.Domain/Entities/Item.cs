using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string SmallImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string CardImageUrl { get; set; }
        public string Description { get; set; }
        public int ItemTypeId { get; set; }
        public int SubTypeId { get; set; }

        public string EquipLocation { get; set; } // location

        /*
         * Lower
         * Middle
         * Upper
         * MiddleUpper
         * UpperMiddleLower
         */
        public bool Refinable { get; set; }

        public virtual ItemMoveInfo ItemMoveInfo { get; set; }
        
        public int RagnaPriceItemTypeId { get; set; } // 5 == ETC
        public int RagnaPriceSubItemTypeId { get; set; }

        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int RequiredLevel { get; set; }
        public int LimitLevel { get; set; }
        public int ItemLevel { get; set; }
        public int Weight { get; set; }
        public int Defense { get; set; }
        public string CardPrefix { get; set; }
        public int Slots { get; set; }
        public string UnidName { get; set; }
        public IEnumerable<NpcItemMap> NpcItemMaps { get; set; }
        public IEnumerable<MonsterItemMap> MonsterItemMaps { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual SubType SubType { get; set; }
    }
}
// "id": 4425,
// "name": "Carta Atroce",
// "imgUrl": "https://static.ragnaplace.com/bro/item/4425.png",
// "collectionImgUrl": "https://static.ragnaplace.com/bro/collection/4425.png",
// "cardImgUrl": "https://static.ragnaplace.com/bro/card/4425.png",
// "description": "ATQ +25.\r\nAo realizar ataques físicos:\r\nChance de ativar [Velocidade de ataque +100%] por 10 segundos.\r\nTipo: Carta \r\nEquipa em: Arma \r\nPeso: 1\r\n"
//
// "id": 7563,
// "name": "Runa Sangrenta",
// "imgUrl": "https://static.ragnaplace.com/bro/item/7563.png",
// "collectionImgUrl": "https://static.ragnaplace.com/bro/collection/7563.png",
// "cardImgUrl": null,
// "description": "Uma brilhante runa vermelha\r\ncomo sangue que possui\r\num símbolo gravado em sua superfície.\r\n_\r\nPeso: 1\r\n"