using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceLogic
{
    public class ItemGeneral
    {
        public ItemGeneral(int itemCode,string itemDesc,int amount,int itemType,int chainId)
        {
            ItemСode = itemCode;
            ItemDesc = itemDesc;
            Amount = amount;
            ItemType = itemType;
            if(ItemType == 0)
            {
                ChainId = chainId;
            }
            else
            {
                ChainId = 0;
            }
           
        }
        public int ItemСode { get; set; }
        public string ItemDesc { get; set; }
        public int Amount { get; set; }
        public int ItemType { get; set; }
        public int ChainId { get; set; }

    }
}
